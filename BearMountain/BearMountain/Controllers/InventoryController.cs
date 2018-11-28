using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Data;
using BearMountain.Models;
using BearMountain.Models.Interfaces;
using BearMountain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    //[Authorize(Policy = "EmailPolicy")]
    public class InventoryController : Controller
    {
        /// <summary>
        /// The product
        /// </summary>
        private readonly IInventory _product;

        /// <summary>
        /// The cart
        /// </summary>
        private readonly ICart _cart;

        /// <summary>
        /// The context
        /// </summary>
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

        /// <summary>Detailses the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
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
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets all basket items in the cart and puts it in a view model
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a view of the cart</returns>
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var cartItems = await _cart.GetAllItemsFromBasket();
            List<Product> products = new List<Product>();
            foreach (var item in cartItems)
            {
                var product = await _product.GetProductById(item.ProductID);
                products.Add(product);
                
            }
            var col = cartItems.Zip(products, (x, y) => new { BasketItem = x, Product = y });
            List<BasketViewModel> BVMList = new List<BasketViewModel>();
            foreach (var item in col)
            {
                if (!item.BasketItem.CheckedOut)
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
            }
            return View(BVMList);
        }

        /// <summary>
        /// Deletes the cart item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns to the cart</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var basketItem = _cart.GetBasketItem(id);
            await _cart.RemoveBasketItem(basketItem);
            return RedirectToAction("Cart");
        }

        /// <summary>
        /// Gets the cart item to be deleted
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a view</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var basketItem = _cart.GetBasketItem(id);
            var product = await _product.GetProductById(basketItem.ProductID);

            BasketViewModel BVM = new BasketViewModel();
            BVM.SKU = product.SKU;
            BVM.Name = product.Name;
            BVM.Price = product.Price;
            BVM.Description = product.Description;
            BVM.Image = product.Image;
            BVM.ProductID = product.ID;

            BVM.Quantity = basketItem.Quantity;
            BVM.CheckedOut = basketItem.CheckedOut;

            return View(BVM);            
        }

        /// <summary>
        /// Edits the specified basket item.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns to the cart</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BasketItem basketItem, int id)
        {
            BasketItem old = _cart.GetBasketItem(id);
            old.Quantity = basketItem.Quantity;
            await _cart.UpdateBasketItem(old);
            return RedirectToAction(nameof(Cart));
        }
    }
}
