using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiscApi.Controllers;

[ApiController]
public class PizzaOrderController : ControllerBase
{
    [HttpPost("/my/pizza-order/cheese/large")]
    public async Task<ActionResult> AddAnOrder([FromBody] OrderRequest request)
    {
        var response = new OrderResponse
        {
            PizzaStyle = "cheese",
            Size = "large",
            Qty = request.Qty.Value,
            SpecialInstructions = request.SpecialInstructions
        };
        return Ok(response);
    }

    [HttpPost("/my/pizza-order/meatlovers/medium")]
    public async Task<ActionResult> AddMeatLoversOrder([FromBody] OrderRequest request)
    {
        var response = new OrderResponse
        {
            PizzaStyle = "meat lovers",
            Size = "medium",
            Qty = request.Qty.Value,
            SpecialInstructions = request.SpecialInstructions
        };
        return Ok(response);
    }
}

public record OrderRequest
{
    [Required]
    public int? Qty { get; set; }
    public string? SpecialInstructions { get; set; }

}

public record OrderResponse
{
    public string PizzaStyle { get; init; } = string.Empty;
    public string Size { get; init; } = string.Empty;
    public int Qty { get; init; }
    public string? SpecialInstructions { get; init; }
}