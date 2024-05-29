using Microsoft.EntityFrameworkCore;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Data.Repositories;

public class ExpenseRepository(DataContext context) : IExpenseRepository
{
    public async Task AddExpenseAsync(Expense expense)
    {
        context.Expenses!.Add(expense);
        
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesAsync() => await context.Expenses!.ToListAsync();

    public async Task<Expense?> GetExpenseByIdAsync(Guid id) => await context.Expenses!.FindAsync(id);

    public async Task UpdateExpenseAsync(Expense expense)
    {
        context.Expenses!.Update(expense);

        await context.SaveChangesAsync();
    }

    public async Task DeleteExpenseAsync(Expense expense)
    {
        context.Expenses!.Remove(expense);

        await context.SaveChangesAsync();
    }
}