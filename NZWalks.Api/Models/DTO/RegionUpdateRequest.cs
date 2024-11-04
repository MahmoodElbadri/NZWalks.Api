using Microsoft.Build.Framework;

namespace NZWalks.Api.Models.DTO;

public class RegionUpdateRequest
{
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
