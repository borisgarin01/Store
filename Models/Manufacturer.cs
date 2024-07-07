using System.ComponentModel.DataAnnotations;

namespace Models;

public sealed record Manufacturer
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(127)]
    [MinLength(1)]
    public string Name { get; init; }
}
