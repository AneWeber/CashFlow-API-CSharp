using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpenseJson request) 
    {
        var useCase = new RegisterExpenseUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
