using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Data;
using BearMountain.Models;
using BearMountain.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    [Authorize(Policy = "EmailPolicy")]
    public class InventoryController : Controller
    {
        /// <summary>
        /// The product
        /// </summary>
        private readonly IInventory _product;

        private readonly ICart _cart;

        private readonly BearMountainDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public InventoryController(IInventory product, ICart cart, BearMountainDbContext context)
        {
            _product = product;
            _cart = cart;
            _context = context;
        }

        /// <summary>
        /// Displays all products
        /// </summary>
        /// <returns>Returns a view of all objects</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProducts());
        }

        /// <summary>
        /// Gets details for a product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a product detail view</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _product.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, int quantity)
        {
            BasketItem item = new BasketItem();
            item.ProductID = id;
            item.UserBasketID = _context.UserBasket.FirstOrDefault().ID;
            item.Quantity = quantity;
            item.CheckedOut = false;
            await _cart.AddBasketItem(item);
            var product = await _product.GetProductById(id);
            return View(product);
        }
    }
}
