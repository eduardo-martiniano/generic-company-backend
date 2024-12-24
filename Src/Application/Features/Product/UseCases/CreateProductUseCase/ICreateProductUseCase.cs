using Application.Core.Interfaces;
using Application.Core.UseCases;
using Application.Features.Product.Repositories;
using Domain.Features.Product.Entities;

namespace Application.Features.Product.UseCases.CreateProductUseCase
{
    public interface ICreateProductUseCase : IUseCase
    {
        Task<CreateProductResult> Execute(CreateProductInput input);
    }

    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductResult> Execute(CreateProductInput input)
        {
            var productEntity = new ProductEntity(input.Name, input.Description, input.Price);
            await _productRepository.AddAsync(productEntity);
            await _unitOfWork.CommitAsync();

            return new CreateProductResult(productEntity);
        }
    }

    public class CreateProductInput : CreateProductBase
    {

    }

    public class CreateProductResult : CreateProductBase
    {
        public int Id { get; private set; }
        public DateTime? CreatedDate { get; set; }

        public CreateProductResult(ProductEntity product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            CreatedDate = product.CreatedDate;
        }
    }

    public class CreateProductBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
