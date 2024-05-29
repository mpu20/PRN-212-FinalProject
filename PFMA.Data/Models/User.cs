using System.ComponentModel.DataAnnotations;
using PFMA.Common;

namespace PFMA.Data.Models;

public class User
{
    [Key] public Guid Id { get; set; }
    [Required] [MaxLength(50)] public string FullName { get; set; } = string.Empty;
    [Required] public string PasswordHash { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public UserStatus Status { get; set; }
    public virtual ICollection<Income>? Incomes { get; set; }
    public virtual ICollection<Expense>? Expenses { get; set; }
    public virtual ICollection<FinancialGoal>? FinancialGoals { get; set; }
}