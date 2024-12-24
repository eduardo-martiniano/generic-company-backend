using Domain.Core;

namespace Domain.Features.Product.Entities
{
    public class ProductEntity : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
 
        public ProductEntity(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Active = true;
            CreatedDate = DateTime.UtcNow;
        }

        protected ProductEntity() { }

        public void Desactive()
        {
            Active = false;
        }

        public void UpdateName(string name)
        {
            Name = name;
            UpdatedDate = DateTime.UtcNow;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            UpdatedDate = DateTime.UtcNow;
        }

        public void UpdatePrice(double price)
        {
            Price = price;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
