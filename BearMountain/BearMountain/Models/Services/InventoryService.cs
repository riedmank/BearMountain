using BearMountain.Data;
using BearMountain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Services
{
    public class InventoryService : IInventory
    {
        private BearMountainDbContext _context;

        public InventoryService(BearMountainDbContext context)
        {
            _context = context;

        }

        public Task CreateProduct()
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetProductById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
