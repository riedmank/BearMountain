using BearMountain.Data;
using BearMountain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Services
{
    public class InventoryService : IInventory
    {
        /// <summary>
        /// The context
        /// </summary>
        private BearMountainDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public InventoryService(BearMountainDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Returns a task</returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a task</returns>
        public async Task DeleteProduct(int id)
        {
            Product product = await GetProductById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a product</returns>
        public async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>Returns a list of products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Returns a task</returns>
        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
