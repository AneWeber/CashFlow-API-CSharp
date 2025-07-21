using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Exception;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert - with Shouldly
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);

    }
}
