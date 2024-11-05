using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories;

public interface IWalkRepository
{
    Task<Walks> CreateAsync(Walks walks);
    Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
    Task<Walks?> GetByIdAsync(Guid id);
    Task<Walks?> UpdateAsync(Guid id, Walks walks);
    Task<Walks?> DeleteAsync(Guid id);
}
