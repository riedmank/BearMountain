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
        private readonly IInventory _inventory;

        public HomeController(IInventory inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}