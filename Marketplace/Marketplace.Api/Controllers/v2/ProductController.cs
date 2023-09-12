using Marketplace.Api.Controllers.BaseControllers;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Output;
using Marketplace.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class productController : ControllerApi
    {
        private readonly IProductService _productService;
        public productController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("paladinos-teste")]
        [ProducesResponseType(typeof(ResultModel<ProductOutputModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTest([FromQuery] long id)
            => Return(new ResultModel<string>().AddResult("Rota unica do V2 para teste"));

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
