using Marketplace.Domain.Entities;
using System.Linq.Expressions;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckExistenceAsync(string cpf);
        Task<bool> RegisterNewUserAsync(UserEntity newUser);
        Task<T> GetDataUserByCpf<T>(Expression<Func<UserEntity, T>> expression, string cpf);
    }
}
