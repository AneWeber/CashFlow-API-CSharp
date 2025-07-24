using CashFlow_Application.UseCases.Expenses.Register;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] CashFlow_Communication.Requests.RequestRegisterExpenseJson request) 
    {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
