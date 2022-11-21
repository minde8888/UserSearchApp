using UserSearchApp.Services.Dtos;

namespace UserSearchApp.Services.ApiClients
{
    public interface IJsonPlaceholderApiClient
    {
        Task<SearchUserInfo> SearchUserAsync(string name);
    }
}