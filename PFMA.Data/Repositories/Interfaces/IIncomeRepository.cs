using PFMA.Data.Models;

namespace PFMA.Data.Repositories.Interfaces;

public interface IIncomeRepository
{
    public Task AddIncomeAsync(Income income);
    public Task<IEnumerable<Income>> GetAllIncomesAsync();
    public Task<Income?> GetIncomeByIdAsync(Guid id);
    public Task UpdateIncomeAsync(Income income);
    public Task DeleteIncomeAsync(Income income);
}