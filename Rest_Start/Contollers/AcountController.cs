using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rest_Start.Models;
using Rest_Start.ViewModels;

namespace Rest_Start.Contollers
{
    public class AcountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AspNetUserManager<IdentityUser> _userManager;

        public AcountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = (AspNetUserManager<IdentityUser>) userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
         public IActionResult Regester()
        {
            return View();
        }
       [Authorize]
        [HttpPost]
        public async Task<IActionResult> Regester(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(){UserName = login.UserName};
                var results = await _userManager.CreateAsync(user, login.Password);

                if (results.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(login);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
       [Authorize] 
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);
            var user = await
                _userManager.FindByNameAsync(login.UserName);
            {
                if (user != null)
                {
                    var results = await
                        _signInManager.PasswordSignInAsync
                            (user, login.Password, false, false);
                    if (results.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("","User name/Passwod not found");
                return View(login);

            }
            
        }
        
       
    }
}