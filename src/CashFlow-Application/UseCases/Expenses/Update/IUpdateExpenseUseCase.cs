using CashFlow_Communication.Requests;

namespace CashFlow_Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
