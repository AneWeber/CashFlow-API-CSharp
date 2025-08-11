using CashFlow_Domain.Security.Cryptography;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow_Infrastructure.Security.Cryptography;
internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        return passwordHash;
    }

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}
