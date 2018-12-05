using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Interfaces
{
    public interface IInventory
    {
        Task CreateProduct(Product product);

        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(int? id);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
