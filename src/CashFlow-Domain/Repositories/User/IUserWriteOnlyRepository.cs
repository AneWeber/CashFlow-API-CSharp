namespace CashFlow_Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    Task Add(Entities.User user);
}
