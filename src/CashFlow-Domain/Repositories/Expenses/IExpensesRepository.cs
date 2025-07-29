using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);
}
