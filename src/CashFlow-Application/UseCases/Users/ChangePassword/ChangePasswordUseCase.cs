using CashFlow_Communication.Requests;
using CashFlow_Domain.Entities;
using CashFlow_Domain.Repositories;
using CashFlow_Domain.Repositories.User;
using CashFlow_Domain.Security.Cryptography;
using CashFlow_Domain.Services.LoggedUser;
using CashFlow_Exception;
using CashFlow_Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow_Application.UseCases.Users.ChangePassword;
public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncrypter _passwordEncrypter;

    public ChangePasswordUseCase(
        ILoggedUser loggedUser,
        IPasswordEncrypter passwordEncrypter,
        IUserUpdateOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _passwordEncrypter = passwordEncrypter;
    }

    public async Task Execute(RequestChangePasswordJson request)
    {
        var loggedUser = await _loggedUser.Get();

        Validate(request, loggedUser);

        var user = await _repository.GetById(loggedUser.Id);
        user.Password = _passwordEncrypter.Encrypt(request.NewPassword);

        _repository.Update(user);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestChangePasswordJson request, User loggedUser)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(request);

        var passwordMatch = _passwordEncrypter.Verify(request.Password, loggedUser.Password);

        if (passwordMatch == false)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
        }

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
