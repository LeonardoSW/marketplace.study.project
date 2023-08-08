using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Models.Output;
using Marketplace.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PostgresContext _context;
        private readonly DbSet<ProductEntity> _dbSet;

        public ProductRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProductEntity>();
        }

        public async Task<ProductOutputModel> GetProductByIdAsync(long id)
            => await _dbSet.Where(x => x.Id == id)
                           .Select(x => new ProductOutputModel(x.Name, x.Description, x.Price, x.Stock))
                           .FirstOrDefaultAsync();

        public async Task<List<ProductOutputModel>> GetProductListByNameAsync(string name)
        {
            try
            {
                var query = _dbSet.AsQueryable();
                if (!string.IsNullOrWhiteSpace(name))
                    query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));

                return await query.Where(x => x.Status == ProductStatusEnum.Active).Select(x => new ProductOutputModel(x.Name, x.Description, x.Price, x.Stock))
                                  .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RegisterNewProductAsync(ProductEntity product)
        {
            try
            {
                await _dbSet.AddAsync(product);
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
