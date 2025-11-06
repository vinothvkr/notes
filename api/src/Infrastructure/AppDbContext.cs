using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>(x => x.ToTable(name: "Users"));
        builder.Entity<IdentityRole>(x => x.ToTable(name: "Roles"));
        builder.Entity<IdentityUserToken<string>>(x => x.ToTable(name: "UserTokens"));
        builder.Entity<IdentityUserRole<string>>(x => x.ToTable(name: "UserRoles"));
        builder.Entity<IdentityUserLogin<string>>(x => x.ToTable(name: "UserLogins"));
        builder.Entity<IdentityUserClaim<string>>(x => x.ToTable(name: "UserClaims"));
        builder.Entity<IdentityRoleClaim<string>>(x => x.ToTable(name: "RoleClaims"));
    }
}
