namespace CashFlow_Domain.Security.Tokens;
public interface ITokenProvider
{
    string TokenOnRequest();
}
