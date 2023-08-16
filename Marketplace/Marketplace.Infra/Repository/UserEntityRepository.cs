using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Marketplace.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<UserEntity> _dbSet;
        private readonly PostgresContext _context;

        public UserRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserEntity>();
        }

        public async Task<bool> CheckExistenceAsync(string cpf)
        {
            try
            {
                return await _dbSet.AnyAsync(x => x.Cpf == cpf);
            }
            catch
            {
                return true;
            }
        }

        public async Task<bool> RegisterNewUserAsync(UserEntity newUser)
        {
            try
            {
                await _dbSet.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> GetDataUserByCpf<T>(Expression<Func<UserEntity, T>> expression, string cpf)
            => await _dbSet.Where(x => x.Cpf == cpf).Select(expression).FirstOrDefaultAsync();
    }
}
