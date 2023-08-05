using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Repository
{
    public class UserEntityRepository : IUserRepository
    {
        private readonly DbSet<UserEntity> _dbSet;
        private readonly PostgresContext _context;

        public UserEntityRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserEntity>();
        }

        public async Task<bool> CheckExistence(string cpf)
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
    }
}
