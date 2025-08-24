using CashFlow.Application.UseCases.Login.DoLogin;
using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;
using CashFlow_Domain.Repositories.User;
using CashFlow_Domain.Security.Cryptography;
using CashFlow_Domain.Security.Tokens;
using CashFlow_Exception.ExceptionsBase;

namespace CashFlow_Application.UseCases.Login.DoLogin;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IUserReadOnlyRepository repository,
        IPasswordEncrypter passwordEncrypter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _passwordEncrypter = passwordEncrypter;
        _repository = repository;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncrypter.Verify(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
