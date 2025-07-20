using CashFlow_Communication.Enums;
using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;
using CashFlow_Exception.ExceptionsBase;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request) 
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

}
