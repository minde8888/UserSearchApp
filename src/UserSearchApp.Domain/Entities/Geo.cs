
namespace UserSearchApp.Domain.Entities
{
    public class Geo
    {
        public int GeoId { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Address Address { get; set; }
    }
}
