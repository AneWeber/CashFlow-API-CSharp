using CashFlow_Application.UseCases.Expenses;
using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Communication.Enums;
using CashFlow_Exception;
using CommonTestUtilities.Requests;
using EmptyFiles;
using Shouldly;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);

    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.DATE_CANNOT_BE_FUTURE);

    }

    [Fact]
    public void Error_Payment_Method_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentMethod = (PaymentMethod)700;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.PAYMENT_INVALID_METHOD);

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    [InlineData(-24)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

    }

    [Fact]
    public void Error_Decription_Empty()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Description = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.DESCRIPTION_REQUIRED);

    }

    [Fact]
    public void Error_Category_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Category = (ExpensesCategories)700;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.CATEGORY_INVALID);

    }
}
