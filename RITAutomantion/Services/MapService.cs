using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RITAutomantion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomantion
{
    internal class MapService : IDisposable, IMapService
    {
        private readonly IRepository<GeoPoint, int> _repository;
        public MapService(IRepository<GeoPoint, int> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<GMapMarker> GetMarkers()
        {
            var overlay = new List<GMapMarker>();
            var markers = _repository.GetAll();

            foreach (var marker in markers)
            {
                var geoPointMarker = new GMarkerGoogle(marker.Point, GMarkerGoogleType.red_small);
                geoPointMarker.Tag = marker.Id;

                overlay.Add(geoPointMarker);
            }

            return overlay;
        }

        public async Task MoveMarker(GMapMarker marker)
        {
            int.TryParse(marker.Tag.ToString(), out int key);
            var point = new GeoPoint(key, marker.Position.Lat, marker.Position.Lng);

            await _repository.Update(point);
        }
    }
}
