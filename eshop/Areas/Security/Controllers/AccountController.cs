using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Controllers;
using eshop.Models;
using eshop.Models.ApplicationServices;
using eshop.Models.Database;
using eshop.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eshop.Areas.Security.Controllers
{
    [Area("Security")]
    [AllowAnonymous]            // pristup povolen vsem
    public class AccountController : Controller
    {
        ISecurityApplicationService iSecure;
        readonly EshopDBContext EshopDBContext;


        public AccountController(ISecurityApplicationService iSecure, EshopDBContext eshopDBContext)
        {
            this.iSecure = iSecure;
            this.EshopDBContext = eshopDBContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            vm.LoginFailed = false;
            if (ModelState.IsValid)
            {
                bool isLogged = await iSecure.Login(vm);

                if (isLogged)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = "" });
                }
                else
                {
                    vm.LoginFailed = true;
                }
            }

            return View(vm);
        }


        public IActionResult Logout()
        {
            iSecure.Logout();
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Register()
        {
            return View();      // return basic View
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            User existingUser = EshopDBContext.User.Where(user => user.UserName == vm.UserName).FirstOrDefault();

            if (existingUser != null)
            {
                ModelState.AddModelError("UserName", "This Username already exist! Please choose another one :-)");
                return View();
            }

            if (ModelState.IsValid)
            {
                vm.ErrorDuringRegister = await iSecure.Register(vm, Models.Identity.Roles.Customer);

                if (vm.ErrorDuringRegister == null)     // succeeded registration
                {
                    var lvm = new LoginViewModel()
                    {
                        UserName = vm.UserName,
                        Password = vm.Password,
                        RememberMe = true,
                        LoginFailed = false
                    };

                    return await Login(lvm);
                }
            }

            return View();
        }

    }
}


