﻿namespace NZWalks.Api.Models.DTO.Walks;

public class WalkDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double? LengthInKm { get; set; }
    public string? Description { get; set; }
    public string? WalkImageUrl { get; set; }
    public RegionDto? Region { get; set; }
    public DifficultyDto.DifficultyDto? Difficulty { get; set; }
}