using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResultModel<string>> RegisterUserAsync(NewUserInputModel input);
    }
}
