using Microsoft.EntityFrameworkCore;
using UserSearchApp.Data.Context;
using UserSearchApp.Domain.Entities;

namespace UserSearchApp.Data.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserInfo> AddUserAsync(UserInfo user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<bool> GetAsyncUser(string name, string userName)
        {
            bool result = await _context.UserInfo.AnyAsync(u => u.Name == name && u.UserName == userName);

            return result;
        }
    }
}
