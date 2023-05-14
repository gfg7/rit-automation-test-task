using GMap.NET;
using RITAutomantion.Contracts;
using RITAutomantion.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RITAutomantion.Models
{
    [Table("GeoPointMarkers")]
    internal class GeoPoint : IEntity<int>, IMappedEntity<GeoPoint>
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; private set; }
        [Column(nameof(Latitude))]
        public double Latitude { get; set; }
        [Column(nameof(Longitude))]
        public double Longitude { get; set; }
        public PointLatLng Point => new PointLatLng(Latitude, Longitude);
        public int GetKey() => Id;

        public GeoPoint() { }
        public GeoPoint(int id, double latitude, double longitude)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
        }

        public GeoPoint Map(DataRow row)
        {
            GeoPoint point = new GeoPoint();
            var properties = point.GetMappedProperties();

            foreach (var property in properties)
            {
                property.SetValue(point, row[property.GetColumnName()]);
            }

            return point;
        }
    }
}
