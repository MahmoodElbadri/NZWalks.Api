﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTO;

public class RegionAddRequest
{
    [Required]
    [StringLength(maximumLength:3,MinimumLength = 3,ErrorMessage ="Code must be 3 characters")]
    public string? Code { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
