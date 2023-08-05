using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResultModel<string>> RegisterNewUserAsync(NewUserInputModel input);
    }
}
