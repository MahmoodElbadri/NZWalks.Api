using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories;

public class WalksRepository : IWalkRepository
{
    private readonly ApplicationDbContext _db;

    public WalksRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Walks> CreateAsync(Walks walks)
    {
        await _db.Walks.AddAsync(walks);
        await _db.SaveChangesAsync();
        return walks;
    }

    public async Task<List<Walks>> GetAllAsync()
    {
        return await _db.Walks.Include(tmp=>tmp.Difficulty).Include(tmp=>tmp.Region).ToListAsync();
    }
    
    public async Task<Walks?> GetByIdAsync(Guid id)
    {
      var region = await _db.Walks
          .Include(tmp => tmp.Difficulty)
          .Include(tmp => tmp.Region)
          .FirstOrDefaultAsync(x => x.Id == id);
      return region ?? null;
    }

    public async Task<Walks?> UpdateAsync(Guid id, Walks walks)
    {
        var existingWalks = await _db.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalks == null)
        {
            return null;
        }
        existingWalks.Name = walks.Name;
        existingWalks.Description = walks.Description;
        existingWalks.LengthInKm = walks.LengthInKm;
        existingWalks.RegionId = walks.RegionId;
        existingWalks.DifficultyId = walks.DifficultyId;
        await _db.SaveChangesAsync();
        return existingWalks;
    }

    public async Task<Walks?> DeleteAsync(Guid id)
    {
        var existingWalk =await _db.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk == null)
        {
            return null;
        }
        _db.Walks.Remove(existingWalk);
        await _db.SaveChangesAsync();
        return existingWalk;
    }
}
