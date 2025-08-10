using CashFlow_Domain.Entities;
using CashFlow_Domain.Repositories.User;
using CashFlow_Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public UserRepository(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
