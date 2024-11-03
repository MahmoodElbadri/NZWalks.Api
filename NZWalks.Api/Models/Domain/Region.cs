using Microsoft.Build.Framework;

namespace NZWalks.Api.Models.Domain;

public class Region
{
    public int Id { get; set; }
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
