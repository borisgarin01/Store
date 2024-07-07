using System.ComponentModel.DataAnnotations;

namespace Models;

public sealed record Product
{
    [Key]
    public long Id { get; init; }

    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string Name { get; init; }

    [MaxLength(8191)]
    public string Description { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;

    public bool IsDeleted { get; init; } = false;
    public DateTime? DeletedAt { get; init; } = null;
    public long CategoryId { get; init; }
    public long ManufacturerId { get; init; }
}