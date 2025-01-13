using Gifits.Korsio.Authorization.Domain.Models.Authorization;
using Gifits.Korsio.Authorization.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Gifits.Korsio.Authorization.Infrastructure.Persistence
{
    public class KorsioDbContext : DbContext
    {
        public KorsioDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<KtUser> Users { get; set; }
        public DbSet<KtRefreshToken> RefreshTokens { get; set; }
    }
}