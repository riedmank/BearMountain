using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Data;
using BearMountain.Models;
using BearMountain.Models.Interfaces;
using BearMountain.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BearMountain.Controllers
{
    public class CheckoutController : Controller
    {
        private BearMountainDbContext _context;

        private ICart _cart;

        private IInventory _product;

        private IEmailSender _email;

        public CheckoutController(BearMountainDbContext context, IInventory product, ICart cart, IEmailSender email)
        {
            _context = context;
            _cart = cart;
            _product = product;
            _email = email;
        }

        [HttpGet]
        public async Task<IActionResult> Receipt(string userName)
        {
            var basketItems = await _cart.GetAllItemsFromBasket();

            List<BasketItem> checkOut = new List<BasketItem>();
            foreach (var item in basketItems)
            {
                if (item.CheckedOut == false)
                {
                    checkOut.Add(item);
                    item.CheckedOut = true;
                    await _cart.UpdateBasketItem(item);
                    await _context.SaveChangesAsync();
                }
            }

            string subject = "Order Confirmation";

            string msg = "<table><th>Product</th><th>Quantity</th><th>Price</th>";

            decimal total = 0m;

            foreach (var item in checkOut)
            {
                var product = await _product.GetProductById(item.ProductID);
                total += (product.Price * item.Quantity);
                msg += $"<tr><td>{product.Name}</td><td>{item.Quantity}</td><td>${product.Price}</td></tr>";
            }

            msg += $"<tr><td></td><td>Total:</td><td>${total}</td></tr></table>";

            await _email.SendEmailAsync(userName, subject, msg);

            List<Product> products = new List<Product>();
            foreach (var item in checkOut)
            {
                var product = await _product.GetProductById(item.ProductID);
                products.Add(product);
            }

            var col = checkOut.Zip(products, (x, y) => new { BasketItem = x, Product = y });
            List<BasketViewModel> BVMList = new List<BasketViewModel>();
            foreach (var item in col)
            {
                BasketViewModel BVM = new BasketViewModel();
                BVM.SKU = item.Product.SKU;
                BVM.Name = item.Product.Name;
                BVM.Price = item.Product.Price;
                BVM.Description = item.Product.Description;
                BVM.Image = item.Product.Image;
                BVM.ProductID = item.Product.ID;

                BVM.Quantity = item.BasketItem.Quantity;
                BVM.CheckedOut = item.BasketItem.CheckedOut;
                BVM.ID = item.BasketItem.ID;
                BVM.UserBasketID = item.BasketItem.UserBasketID;
                BVMList.Add(BVM);
            }
            return View(BVMList);
        }        
    }
}