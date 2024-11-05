using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walks> Walks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var difficulties = new List<Difficulty>()
        {
            new Difficulty { Id = Guid.NewGuid(), Name = "Easy" },
            new Difficulty { Id = Guid.NewGuid(), Name = "Medium" },
            new Difficulty { Id = Guid.NewGuid(), Name = "Hard" }
        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);
        var regions = new List<Region>()
        {
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Wellington",
                Code = "WLG",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Christchurch",
                Code = "CHC",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Tauranga",
                Code = "TRG",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region()
            {
                Id = Guid.NewGuid(),
                Name = "New York",
                Code = "NYC",
                RegionImageUrl =
                    "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            }
        };
        modelBuilder.Entity<Region>().HasData(regions);
        
       /* var walks = new List<Walks>()
        {
            new Walks()
            {
                Id = Guid.NewGuid(),
                Name = "Mount Victoria Lookout Walk",
                Description = "This is an easy 20 - 30 minutes walk to the lookout in Mt. Victoria",
                Difficulty = "314366DC-8188-463B-8F37-7C465AF76EB7",
                Region = "73B907F0-A057-4C57-B145-F7C29EDD1D82",
                
            }
        }*/
    }
    
}
