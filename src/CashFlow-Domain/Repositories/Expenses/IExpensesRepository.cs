using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
}
