using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultModel<string>> RegisterUserAsync(NewUserInputModel input)
        {
            var result = new ResultModel<string>();

            var userExists = await _userRepository.CheckExistence(input.Cpf);
            if (userExists)
                return result.AddError(ServiceResources.UserAlreadExists);

            var statusRegister = await _userRepository.RegisterNewUserAsync(new UserEntity(input));
            if (statusRegister)
                return result.AddResult(ServiceResources.UserRegistred);

            return result.AddError(ServiceResources.UserRegisterFail);
        }
    }
}