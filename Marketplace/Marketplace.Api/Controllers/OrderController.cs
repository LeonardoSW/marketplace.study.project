using Marketplace.Api.Controllers.BaseControllers;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerApi
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] NewOrderInputModel input)
        {
            return Return(await _orderService.CreateNewOrderAsync(input));
        }
    }
}
