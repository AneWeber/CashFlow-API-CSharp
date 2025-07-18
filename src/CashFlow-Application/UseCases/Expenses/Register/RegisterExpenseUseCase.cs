using CashFlow_Communication.Enums;
using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestExpenseJson request) 
    {
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required.");
        }

        var descriptionIsEmpty = string.IsNullOrWhiteSpace(request.Description);
        if (descriptionIsEmpty)
        {
            throw new ArgumentException("Description is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var dateIsPast = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateIsPast > 0)
        {
            throw new ArgumentException("Date cannot be in the future.");
        }

        var expensesCategoryIsValid = Enum.IsDefined(typeof(ExpensesCategories), request.Category);
        if(!expensesCategoryIsValid)
        {
            throw new ArgumentException("Invalid category.");
        }

        var paymentMethodIsValid = Enum.IsDefined(typeof(PaymentMethod), request.PaymentMethod);
        if (!paymentMethodIsValid)
        {
            throw new ArgumentException("Invalid payment method.");
        }
    }

}
