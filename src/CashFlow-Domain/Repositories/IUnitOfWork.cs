namespace CashFlow_Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
