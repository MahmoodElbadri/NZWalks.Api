﻿using Microsoft.Build.Framework;

namespace NZWalks.Api.Models.Domain;

public class Region
{
    public Guid Id { get; set; }
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
