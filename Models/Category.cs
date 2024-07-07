using System.ComponentModel.DataAnnotations;

namespace Models;

public sealed record Category
{
    [Key]
    public long Id { get; init; }

    [Required]
    [MaxLength(127)]
    [MinLength(1)]
    public string Name { get; init; }
}
