using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<User> Get();
}