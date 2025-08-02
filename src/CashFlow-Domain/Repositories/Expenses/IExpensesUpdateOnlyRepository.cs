using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Repositories.Expenses;
public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(long id);
    void Update(Expense expense);
}
