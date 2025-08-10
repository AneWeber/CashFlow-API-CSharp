using CashFlow_Domain.Security.Cryptography;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow_Infrastructure.Security;
internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        return passwordHash;
    }
}
