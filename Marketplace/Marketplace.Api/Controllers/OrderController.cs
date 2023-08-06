using Marketplace.Api.Controllers.BaseControllers;
using Marketplace.Domain.Interfaces.Services;
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
        public IActionResult Teste()
        {
            _orderService.Teste("{\"Teste\":123");
            return Ok();
        }
    }
}
