using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Expenses.GetAll;

public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesJson> Execute();
}