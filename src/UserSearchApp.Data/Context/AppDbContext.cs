using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserSearchApp.Domain.Entities;

namespace UserSearchApp.Data.Context
{
    public class AppDbContext : IdentityDbContext
    {       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserInfo>()
            .HasOne(b => b.Address)
            .WithOne(i => i.UserInfo)
            .HasForeignKey<UserInfo>(b => b.UserInfoId);

            builder.Entity<Address>()
            .HasOne(b => b.Geo)
            .WithOne(i => i.Address)
            .HasForeignKey<Address>(b => b.AddressId);
        }
    }
}
