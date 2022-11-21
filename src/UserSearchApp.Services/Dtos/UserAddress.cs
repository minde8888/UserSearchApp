

namespace UserSearchApp.Services.Dtos
{
    public class UserAddress
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public UserGeo Geo { get; set; }
    }
}
