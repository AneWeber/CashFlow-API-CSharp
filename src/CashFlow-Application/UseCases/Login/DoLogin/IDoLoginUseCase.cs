using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;

namespace CashFlow.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}