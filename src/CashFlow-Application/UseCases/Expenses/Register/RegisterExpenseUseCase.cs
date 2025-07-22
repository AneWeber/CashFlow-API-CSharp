using CashFlow_Communication.Enums;
using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;
using CashFlow_Domain.Entities;
using CashFlow_Exception.ExceptionsBase;
using CashFlow_Infrastructure.DataAccess;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request) 
    {
        Validate(request);

        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date,
            Category = (CashFlow_Domain.Enums.ExpensesCategories)request.Category,
            PaymentMethod = (CashFlow_Domain.Enums.PaymentMethod)request.PaymentMethod,
            Notes = request.Notes
        };

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
