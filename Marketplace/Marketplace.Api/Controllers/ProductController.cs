using Marketplace.Api.Controllers.BaseControllers;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Output;
using Marketplace.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerApi
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResultModel<ProductOutputModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery] long id)
            => Return(await _productService.GetProductByIdAsync(id));

        [HttpGet("filter")]
        [ProducesResponseType(typeof(ResultModel<List<ProductOutputModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductListByName([FromQuery] string name)
            => Return(await _productService.GetProductListByNameAsync(name));

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<List<ProductOutputModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterNewProduct([FromBody] NewProductInputModel input)
            => Return(await _productService.RegisterNewProductAsync(input));
    }
}
