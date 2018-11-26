using BearMountain.Data;
using BearMountain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Services
{
    public class CartService : ICart
    {
        private BearMountainDbContext _context;

        public CartService(BearMountainDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the basket item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Returns a task</returns>
        public async Task AddBasketItem(BasketItem item)
        {
            _context.BasketItems.Add(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all items for basket identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns all basket items</returns>
        public async Task<IEnumerable<BasketItem>> GetAllItemsForBasketID(int? id)
        {
            return await _context.BasketItems.ToListAsync();
        }

        /// <summary>
        /// Gets the basket item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a specific basket item</returns>
        public BasketItem GetBasketItem(int id)
        {
            BasketItem basketItem = _context.BasketItems.FirstOrDefault(item => item.ID == id);
            return basketItem;
        }

        /// <summary>
        /// Updates the basket item.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        /// <returns>Returns a task</returns>
        public async Task UpdateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Update(basketItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the basket item.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        /// <returns>Returns a task</returns>
        public async Task RemoveBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();
        }
    }
}
