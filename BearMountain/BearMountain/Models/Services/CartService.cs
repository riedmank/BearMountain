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

        public async Task AddBasketItem(BasketItem item)
        {
            _context.BasketItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BasketItem>> GetAllItemsForBasketID(int? id)
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task RemoveBasketItem(int basketId, int productId)
        {
            BasketItem basketItem = await _context.BasketItems.FirstOrDefaultAsync(item => item.BasketID == basketId && item.ProductID == productId);
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();

        }
    }
}
