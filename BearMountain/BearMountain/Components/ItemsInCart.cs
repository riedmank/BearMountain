using BearMountain.Data;
using BearMountain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Components
{
    public class ItemsInCart : ViewComponent
    {
        private BearMountainDbContext _context;

        public ItemsInCart(BearMountainDbContext context)
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(string email)
        {
            var id = _context.UserBasket.FirstOrDefault(e => e.UserID == email).ID;

            var basketItemsInCart =  await _context.BasketItems.Where(cart => cart.UserBasketID == id).ToListAsync();

            return View(basketItemsInCart);
        }
    }
}
