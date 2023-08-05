using Marketplace.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers.BaseControllers
{
    public class ControllerApi : ControllerBase
    {
        public IActionResult Return<T>(ResultModel<T> result)
            => result.Success ? Ok(result) : BadRequest(result);
    }
}
