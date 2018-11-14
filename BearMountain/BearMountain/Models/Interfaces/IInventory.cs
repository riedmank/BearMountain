using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Interfaces
{
    public interface IInventory
    {
        Task CreateProduct();

        Task GetProducts();

        Task GetProductById(int? id);

        Task UpdateProduct();

        Task DeleteProduct(int id);
    }
}
