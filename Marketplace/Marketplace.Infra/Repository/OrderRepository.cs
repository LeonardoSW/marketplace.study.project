using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PostgresContext _context;
        private readonly DbSet<OrderEntity> _dbSet;

        public OrderRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<OrderEntity>();
        }

        public async Task ProcessNewOrderAsync(OrderEntity newOrder)
        {
            await _dbSet.AddAsync(newOrder);
        }
    }
}
