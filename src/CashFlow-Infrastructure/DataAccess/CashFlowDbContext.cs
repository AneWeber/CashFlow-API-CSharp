using Microsoft.EntityFrameworkCore;

namespace CashFlow_Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public DbSet<CashFlow_Domain.Entities.Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflowdb;User=root;Password=@Password123;";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
