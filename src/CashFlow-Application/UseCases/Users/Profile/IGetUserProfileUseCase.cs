using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Users.Profile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}