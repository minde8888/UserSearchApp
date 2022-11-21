

namespace UserSearchApp.Services.Dtos
{
    public class SearchUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public UserAddress Address { get; set; }
    }
}