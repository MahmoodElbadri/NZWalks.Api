using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories;

public class RegionRepository:IRegionRepository
{
    private readonly ApplicationDbContext _db;

    public RegionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _db.Regions.ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
        return await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _db.Regions.AddAsync(region);
        await _db.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> UpdateAsync(Region region,Guid id)
    {
        var existingRegion = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null) 
        {
            return null;
        }
        existingRegion.Code = region.Code;
        existingRegion.Name = region.Name;
        existingRegion.RegionImageUrl = region.RegionImageUrl;
        await _db.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var region = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (region == null) 
        {
            return null;
        }
        _db.Regions.Remove(region);
        await _db.SaveChangesAsync();
        return region;
    }
}
