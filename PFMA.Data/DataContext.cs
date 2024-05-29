using Microsoft.EntityFrameworkCore;
using PFMA.Data.Models;

namespace PFMA.Data;

public class DataContext : DbContext
{
    #region DbSet

    public DbSet<User>? Users { get; set; }
    public DbSet<Expense>? Expenses { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Income>? Incomes { get; set; }
    public DbSet<FinancialGoal>? FinancialGoals { get; set; }

    #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(local);database=PFMA;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}