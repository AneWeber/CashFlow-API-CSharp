using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
