using Bogus;
using CashFlow_Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        return new Faker<RequestExpenseJson>()
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Amount, f => f.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.Date, f => f.Date.Past())
            .RuleFor(r => r.Category, f => f.PickRandom<CashFlow_Communication.Enums.ExpensesCategories>())
            .RuleFor(r => r.PaymentMethod, f => f.PickRandom<CashFlow_Communication.Enums.PaymentMethod>());
    }
}
