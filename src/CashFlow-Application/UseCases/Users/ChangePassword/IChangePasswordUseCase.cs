using CashFlow_Communication.Requests;

namespace CashFlow_Application.UseCases.Users.ChangePassword;
public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}