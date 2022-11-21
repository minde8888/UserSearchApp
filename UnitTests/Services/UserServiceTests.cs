using AutoFixture.Xunit2;
using Moq;
using UserSearchApp.Services.ApiClients;
using UserSearchApp.Services.Dtos;
using UserSearchApp.Services.Exceptions;
using UserSearchApp.Services.Services;
using Xunit;

namespace UnitTests.Services
{
    
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IJsonPlaceholderApiClient> _jsonPlaceholderClientMock;

        public UserServiceTests()
        {
            _jsonPlaceholderClientMock = new Mock<IJsonPlaceholderApiClient>();
           _userService = new UserService(_jsonPlaceholderClientMock.Object);
        }

        [Fact]
        public async Task SearchAsync_GivenIncorrectName_UserNotFoundException()
        {
            //result
            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.SearchAsync("test"));           
        }

        [Theory, AutoData]
        public async Task SearchAsync_GivenValidName_ReturnsResult(SearchUserInfo searchUserInfo)
        {
            // arrange
            _jsonPlaceholderClientMock.Setup(m => m.SearchUserAsync(searchUserInfo.Name)).ReturnsAsync(searchUserInfo);
            //act
            var result = await _userService.SearchAsync(searchUserInfo.Name);
            //result
            Assert.Equal(result, searchUserInfo);
            _jsonPlaceholderClientMock.Verify(m => m.SearchUserAsync(searchUserInfo.Name), Times.Once);
        }
    }
}
