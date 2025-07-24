using Microsoft.EntityFrameworkCore;

namespace CashFlow_Infrastructure.DataAccess;
internal class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) { }
    public DbSet<CashFlow_Domain.Entities.Expense> Expenses { get; set; }

}
