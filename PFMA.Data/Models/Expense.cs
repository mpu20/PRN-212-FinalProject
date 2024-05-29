using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMA.Data.Models;

public class Expense
{
    [Key] public Guid Id { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] public Guid CategoryId { get; set; }
    [Required] public decimal Amount { get; set; }
    [Required] public DateTime IncurredDate { get; set; }
    [ForeignKey("UserId")] public virtual User User { get; set; } = null!;
    [ForeignKey("CategoryId")] public virtual Category Category { get; set; } = null!;
}