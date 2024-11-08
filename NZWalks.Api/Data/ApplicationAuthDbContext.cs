using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.Api.Data;

public class ApplicationAuthDbContext:IdentityDbContext
{
    public ApplicationAuthDbContext(DbContextOptions<ApplicationAuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "reader",
                NormalizedName = "reader".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "writer",
                NormalizedName = "writer".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
