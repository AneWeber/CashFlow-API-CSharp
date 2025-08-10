using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
