using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public InventoryController(IInventory product)
        {
            _product = product;
        }

        /// <summary>
        /// Displays all products
        /// </summary>
        /// <returns>Returns a view of all objects</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProducts());
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
