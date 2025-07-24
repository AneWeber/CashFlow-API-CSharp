using CashFlow_Domain.Entities;
using CashFlow_Domain.Repositories.Expenses;

namespace CashFlow_Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
    }
}
