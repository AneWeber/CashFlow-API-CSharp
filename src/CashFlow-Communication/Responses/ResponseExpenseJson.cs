using CashFlow_Communication.Enums;

namespace CashFlow_Communication.Responses;
public class ResponseExpenseJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public ExpensesCategories Category { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
