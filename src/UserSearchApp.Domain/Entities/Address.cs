
namespace UserSearchApp.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public UserInfo UserInfo { get; set; }
        public Geo Geo { get; set; }
    }
}
