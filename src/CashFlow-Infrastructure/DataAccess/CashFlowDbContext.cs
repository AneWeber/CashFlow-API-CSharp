using CashFlow_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow_Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

}
