using CashFlow_Communication.Requests;
using CashFlow_Exception;
using FluentValidation;

namespace CashFlow_Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Description).NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_REQUIRED);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATE_CANNOT_BE_FUTURE);
        RuleFor(expense => expense.Category).IsInEnum().WithMessage(ResourceErrorMessages.CATEGORY_INVALID);
        RuleFor(expense => expense.PaymentMethod).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_INVALID_METHOD);
    }
}
