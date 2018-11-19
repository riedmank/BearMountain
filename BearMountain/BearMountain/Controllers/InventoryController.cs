using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventory _product;

        public InventoryController(IInventory product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProducts());
        }
    }
}
