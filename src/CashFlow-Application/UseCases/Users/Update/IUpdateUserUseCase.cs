using CashFlow_Communication.Requests;

namespace CashFlow_Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}