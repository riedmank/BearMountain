using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BearMountain.Data;
using BearMountain.Models;
using BearMountain.Models.Interfaces;
using BearMountain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BearMountain.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private SignInManager<ApplicationUser> _signInManager;

        private BearMountainDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BearMountainDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns>Returns View</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the specified RVM.
        /// </summary>
        /// <param name="rvm">The RVM.</param>
        /// <returns>Redirects back to home</returns>
        [HttpPost]
        [AllowAnonymous]
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

                UserBasket newUserBasket = new UserBasket();
                newUserBasket.UserID = user.Email;

                _context.UserBasket.Add(newUserBasket);
                await _context.SaveChangesAsync();

                if(result.Succeeded)
                {

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim emailClaim = new Claim("Email", user.Email, ClaimValueTypes.Email);

                    List<Claim> myclaims = new List<Claim>()
                    {
                        fullNameClaim,
                        emailClaim
                    };

                    await _userManager.AddClaimsAsync(user, myclaims);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");

                }
            }

            return View();
        }

        /// <summary>
        /// Allows the user to login
        /// </summary>
        /// <returns>Returns the login page view</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logins the specified LVM.
        /// </summary>
        /// <param name="lvm">The LVM.</param>
        /// <returns>Returns to the home page upon successful login</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect User Name or password!");
                }
            }

            return View(lvm);
        }
    }
}