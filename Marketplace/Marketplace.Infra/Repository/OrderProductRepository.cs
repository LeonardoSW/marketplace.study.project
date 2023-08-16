using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly PostgresContext _context;
        private readonly DbSet<OrderProductEntity> _dbSet;

        public OrderProductRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<OrderProductEntity>();
        }
        public async Task CommitAsync()
            => await _context.SaveChangesAsync();

        public async Task InsertNewOrderProductsAsync(List<OrderProductEntity> products)
        {
            await _dbSet.AddRangeAsync(products);
        }

    }
}
