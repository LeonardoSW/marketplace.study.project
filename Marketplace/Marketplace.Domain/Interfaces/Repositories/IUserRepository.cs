using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckExistenceAsync(string cpf);
        Task<bool> RegisterNewUserAsync(UserEntity newUser);
    }
}
