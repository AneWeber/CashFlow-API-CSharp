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
        return Created();
    }
}
