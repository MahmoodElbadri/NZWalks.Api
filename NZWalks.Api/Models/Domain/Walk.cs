﻿using Microsoft.Build.Framework;

namespace NZWalks.Api.Models.Domain;

public class Walk
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public double? LengthInKm { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid? DifficultyId { get; set; }
    public Difficulty? Difficulty { get; set; }
    public Guid RegionId { get; set; }
    public Region? Region { get; set; }
}
