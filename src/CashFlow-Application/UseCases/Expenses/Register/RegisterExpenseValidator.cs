using CashFlow_Communication.Requests;
using FluentValidation;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(expense => expense.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");
        RuleFor(expense => expense.Category).IsInEnum().WithMessage("Invalid category.");
        RuleFor(expense => expense.PaymentMethod).IsInEnum().WithMessage("Invalid payment method.");
    }
}
