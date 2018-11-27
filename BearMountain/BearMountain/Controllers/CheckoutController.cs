using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public ActionResult Receipt()
        {
            return View();
        }

        
    }
}