using System.ComponentModel.DataAnnotations;

namespace PFMA.Data.Models;

public class Category
{
    [Key] public Guid Id { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    public virtual ICollection<Expense>? Expenses { get; set; }
}