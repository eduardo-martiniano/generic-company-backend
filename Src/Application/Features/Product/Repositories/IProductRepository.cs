using Domain.Features.Product.Entities;

namespace Application.Features.Product.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> AddAsync(ProductEntity product);
    }
}
