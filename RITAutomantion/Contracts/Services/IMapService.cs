using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RITAutomantion
{
    public interface IMapService
    {
        void Dispose();
        IEnumerable<GMapMarker> GetMarkers();
        Task MoveMarker(GMapMarker marker);
    }
}