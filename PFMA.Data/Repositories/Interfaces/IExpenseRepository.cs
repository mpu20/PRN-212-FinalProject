using PFMA.Data.Models;

namespace PFMA.Data.Repositories.Interfaces;

public interface IExpenseRepository
{
    public Task AddExpenseAsync(Expense expense);
    public Task<IEnumerable<Expense>> GetAllExpensesAsync();
    public Task<Expense?> GetExpenseByIdAsync(Guid id);
    public Task UpdateExpenseAsync(Expense expense);
    public Task DeleteExpenseAsync(Expense expense);
}