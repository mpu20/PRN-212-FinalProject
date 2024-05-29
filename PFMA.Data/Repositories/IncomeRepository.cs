using Microsoft.EntityFrameworkCore;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Data.Repositories;

public class IncomeRepository(DataContext context) : IIncomeRepository
{
    public async Task AddIncomeAsync(Income income)
    {
        if (await GetIncomeByIdAsync(income.Id) != null) 
            throw new Exception("Income already exists.");
        
        context.Incomes!.Add(income);
        
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Income>> GetAllIncomesAsync() => await context.Incomes!.ToListAsync();

    public async Task<Income?> GetIncomeByIdAsync(Guid id) => await context.Incomes!.FindAsync(id);

    public Task UpdateIncomeAsync(Income income)
    {
        context.Incomes!.Update(income);
        
        return context.SaveChangesAsync();
    }

    public Task DeleteIncomeAsync(Income income)
    {
        context.Incomes!.Remove(income);
        
        return context.SaveChangesAsync();
    }
}