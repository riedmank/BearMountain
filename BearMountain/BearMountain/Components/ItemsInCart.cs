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

        public ItemsInCart(BearMountainDbContext context, )
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(string email)
        {
            var id = _context.UserBasket.First(e => e.UserID == email).ID;

            var basketItemsInCart =  await _context.BasketItems.Where(cart => cart.UserBasketID == id).ToListAsync();

            foreach (var item in basketItemsInCart)
            {
                var productDetails = _context.Products.Where(p => p.ID == item.ID);

                new CartViewModel
                {
                    ProductID = item.ProductID,
                    UserBasketID = item.UserBasketID,
                    Quantity = item.Quantity,
                    CheckedOut = item.CheckedOut,
                    SKU = productDetails.FirstOrDefault(p => p.ID == item.ProductID).SKU,
                    Description = productDetails.FirstOrDefault(p => p.ID == item.ProductID).Description,
                    Image = productDetails.FirstOrDefault(p => p.ID == item.ProductID).Image,
                    Name = productDetails.FirstOrDefault(p => p.ID == item.ProductID).Name,
                    Price = productDetails.FirstOrDefault(p => p.ID == item.ProductID).Price
                };
            }

            return View(basketItemsInCart);
        }
    }
}
