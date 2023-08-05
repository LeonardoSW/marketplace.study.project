using Marketplace.Domain.Entities;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Repository
{
    public class UserEntityRepository
    {
        private readonly DbSet<UserEntity> _dbSet;
        public UserEntityRepository(PostgresContext context)
        {
            _dbSet = context.Set<UserEntity>();
        }
    }
}
