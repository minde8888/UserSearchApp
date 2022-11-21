using AutoMapper;
using Azure;
using UserSearchApp.Data.Repositories;
using UserSearchApp.Domain.Entities;
using UserSearchApp.Domain.Exceptions;
using UserSearchApp.Services.ApiClients;
using UserSearchApp.Services.Dtos;
using UserSearchApp.Services.Exceptions;

namespace UserSearchApp.Services.Services
{
    public class UserService
    {
        private readonly IJsonPlaceholderApiClient _jsonPlaceholderApiClient;
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IJsonPlaceholderApiClient jsonPlaceholderApiClient,
            IMapper mapper,
            UserRepository userRepository)
        {
            _jsonPlaceholderApiClient = jsonPlaceholderApiClient;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserInfo> SearchAsync(string name)
        {
            var result = await _jsonPlaceholderApiClient.SearchUserAsync(name);
            if (result == null)
            {
                throw new UserNotFoundException();
            }

            var userAleredyExist = await DublicateCheck(result.Name, result.Username);
            if (userAleredyExist)
            {
                throw new UserExistsException();
            }

            var user = _mapper.Map<UserInfo>(result);

            var response = await _userRepository.AddUserAsync(user);
            await UserExistCheck(response.Name, response.UserName);

            return response;
        }

        public async Task<bool> DublicateCheck(string name, string unserName)
        {
            var userExist = await _userRepository.GetAsyncUser(name, unserName);
            return userExist;
        }

        public async Task UserExistCheck(string name, string unserName)
        {
            var userExist = await _userRepository.GetAsyncUser(name, unserName);

            if (!userExist)
            {
                await SearchAsync(name);
            }
        }
    }
}