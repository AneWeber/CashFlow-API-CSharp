using CashFlow_Application.UseCases.Users.Register;
using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
