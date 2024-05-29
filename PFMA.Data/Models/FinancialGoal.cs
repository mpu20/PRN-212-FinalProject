using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMA.Data.Models;

public class FinancialGoal
{
    [Key] public Guid Id { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required] public decimal TargetAmount { get; set; }
    [DefaultValue(0)] public decimal CurrentAmount { get; set; }
    [Required] public DateTime DueDate { get; set; }
    public string? Description { get; set; }
    [ForeignKey("UserId")] public virtual User User { get; set; } = null!;
}