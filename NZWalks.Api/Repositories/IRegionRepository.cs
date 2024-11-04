﻿using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();
    Task<Region?> GetByIdAsync(Guid id);
    Task<Region> CreateAsync(Region region);
    Task<Region?> UpdateAsync(Region region);
    Task<Region?> DeleteAsync(Guid id);
}
