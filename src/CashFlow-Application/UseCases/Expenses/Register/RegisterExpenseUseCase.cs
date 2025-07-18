using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestExpenseJson request) 
    {
        return new ResponseRegisteredExpenseJson();
    }

}
