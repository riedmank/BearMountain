using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BearMountain.Controllers
{
    public class CheckoutController : Controller
    {
        private BearMountainDbContext _context;

        public CheckoutController(BearMountainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Receipt(string email)
        {
            var id = _context.UserBasket.FirstOrDefault(e => e.UserID == email).ID;

            var purchasedItems = await _context.BasketItems.Where(cart => cart.UserBasketID == id && cart.CheckedOut == true).ToListAsync();

            return View();
        }

        
    }
}