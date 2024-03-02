// Interfaces/IProductRepository.cs
using EventTicketAPI.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
    Task AddProductAsync(Product product);
}