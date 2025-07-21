using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Communication.Requests;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson 
        { 
            Title = "Test Expense",
            Description = "This is a test expense",
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Category = CashFlow_Communication.Enums.ExpensesCategories.Miscellaneous,
            PaymentMethod = CashFlow_Communication.Enums.PaymentMethod.CreditCard
        };

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid, "Validation should succeed for valid expense data.");
    }
}
