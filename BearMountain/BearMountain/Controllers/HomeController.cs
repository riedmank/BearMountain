using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The inventory
        /// </summary>
        private readonly IInventory _inventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public HomeController(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// Landing Page
        /// </summary>
        /// <returns>Returns the home page view</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}