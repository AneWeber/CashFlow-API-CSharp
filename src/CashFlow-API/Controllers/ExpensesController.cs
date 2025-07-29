using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] CashFlow_Communication.Requests.RequestRegisterExpenseJson request) 
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
