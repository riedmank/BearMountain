using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearMountain.Models;
using BearMountain.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns>Returns View</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the specified RVM.
        /// </summary>
        /// <param name="rvm">The RVM.</param>
        /// <returns>Returns view</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
            }
            return View();
        }
    }
}