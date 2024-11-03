using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTO;

public class RegionDto
{
    public Guid Id { get; set; }
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
