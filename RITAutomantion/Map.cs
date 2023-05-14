using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RITAutomantion
{
    public partial class Map : Form
    {
        private readonly IMapService _mapService;
        private GMapMarker _currentMarker;
        private readonly GMapOverlay _overlay;
        private bool _grabbing = false;
        private RectLatLng _mapImage;

        public Map(IMapService mapService)
        {
            InitializeComponent();
            _mapService = mapService;
            _overlay = new GMapOverlay()
            {
                IsVisibile = false
            };
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mapService.Dispose();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            MapControl.Overlays.Add(_overlay);
            MapControl.DragButton = MouseButtons.Right;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            MapControl.MapProvider = GMapProviders.GoogleMap;

            LoadingBar.Visible = true;
            LoadMarkersWorker.RunWorkerAsync();
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _currentMarker != null)
            {
                _currentMarker.Position = MapControl.FromLocalToLatLng(e.Location.X, e.Location.Y);
                _mapService.MoveMarker(_currentMarker).ConfigureAwait(false).GetAwaiter();
                MapControl.UpdateMarkerLocalPosition(_currentMarker);
                MapControl.Update();
                _currentMarker = null;
                _grabbing = false;
                MapControl.Cursor = Cursors.Default;
            }
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentMarker != null)
            {
                _grabbing = true;
            }
        }

        private void MapControl_OnMarkerEnter(GMapMarker item)
        {
            if (!_grabbing)
            {
                _currentMarker = item;
            }
        }

        private void MapControl_OnMarkerLeave(GMapMarker item)
        {
            if (!_grabbing)
            {
                _currentMarker = null;
            }
        }

        private void LoadMarkersWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var markers = _mapService.GetMarkers();

            markers.ToList().ForEach(x => _overlay.Markers.Add(x));
        }

        private void LoadMarkersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _overlay.IsVisibile = true;
            LoadingBar.Visible = false;
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_grabbing)
            {
                MapControl.Cursor = Cursors.Cross;
            }
        }
    }
}
