using CashFlow_Communication.Requests;
using FluentValidation;

namespace CashFlow_Application.UseCases.Users.ChangePassword;
public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}