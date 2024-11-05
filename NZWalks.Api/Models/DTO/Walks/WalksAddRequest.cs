using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTO.Walks;

public class WalksAddRequest
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    public double? LengthInKm { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? WalkImageUrl { get; set; }
    [Required]
    public Guid? DifficultyId { get; set; }
    [Required]
    public Guid? RegionId { get; set; }
}
