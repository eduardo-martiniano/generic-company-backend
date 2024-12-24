using Application.Features.Product.Repositories;
using Domain.Features.Product.Entities;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProductEntity> AddAsync(ProductEntity product)
        {
            await _appDbContext.Products.AddAsync(product);
            return product;
        }
    }
}
