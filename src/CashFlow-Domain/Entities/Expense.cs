using CashFlow_Domain.Enums;

namespace CashFlow_Domain.Entities;
public class Expense
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public ExpensesCategories Category { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? Notes { get; set; }

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}
