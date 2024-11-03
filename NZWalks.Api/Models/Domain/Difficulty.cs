using Microsoft.Build.Framework;

namespace NZWalks.Api.Models.Domain;

public class Difficulty
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
}
