using Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly IMediator _mediatr;

    public CustomerController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody]RegisterCustomerCommand message)
    {
        var response = _mediatr.Send(message);
        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult UpdateCustomer([FromRoute] Guid id, [FromBody]UpdateCustomerCommand message)
    {
        var response = _mediatr.Send(message);
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCustomer([FromRoute] Guid id, [FromBody]DeleteCustomerCommand message)
    {
        var response = _mediatr.Send(message);
        return Ok(response);
    }
}