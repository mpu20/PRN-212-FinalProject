using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMA.Data.Models;

public class Income
{
    [Key] public Guid Id { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] [MaxLength(100)] public string Source { get; set; } = string.Empty;
    [Required] public decimal Amount { get; set; }
    [Required] public DateTime ReceivedDate { get; set; }
    public string? Description { get; set; } = string.Empty;
    [ForeignKey("UserId")] public virtual User User { get; set; } = null!;
}