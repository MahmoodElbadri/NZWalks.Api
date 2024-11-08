using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories;

public interface IWalkRepository
{
    Task<Walks> CreateAsync(Walks walks);
    Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
        string? sortBy = null, bool? isAscending = true, int pageNumber = 1, int pageSize = 100
        );
    Task<Walks?> GetByIdAsync(Guid id);
    Task<Walks?> UpdateAsync(Guid id, Walks walks);
    Task<Walks?> DeleteAsync(Guid id);
}
