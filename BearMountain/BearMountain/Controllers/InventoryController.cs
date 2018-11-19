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
        private readonly IInventory _product;

        public InventoryController(IInventory product)
        {
            _product = product;
        }

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
