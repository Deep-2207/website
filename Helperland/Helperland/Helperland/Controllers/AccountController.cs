using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class AccountController : Controller
    {
        private readonly HelperlandContext _helperlandContext;

        public AccountController(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    FirstName = model.firstname,
                    LastName = model.lastname,
                    Email = model.email,
                    Mobile = model.mobileno,
                    Password = model.Password,
                    CreatedDate = DateTime.Now,
                    UserTypeId = (int)UserTypeEnum.Customer,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = (int)UserTypeEnum.Customer,
                    IsApproved = true
                };

                _helperlandContext.Add(user);
                _helperlandContext.SaveChanges();
                TempData["Message"] = "Account Created Successfully";
                return RedirectToAction();
            }
            return View();
        }


        public IActionResult BecomeAPro()
        {
            ViewBag.page = "home";
            ViewBag.provider = "provider";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel model)
        {

            //User user = await _helperlandContext.Users.FindAsync(x => x.Email == model.Email && x.Password == model.Password);
            User user = await _helperlandContext.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            if (user != null && user.IsActive == true)
            {
                //return RedirectToAction("index", "Home");
                if (user.UserTypeId == (int)UserTypeEnum.Customer)
                {
                    RedirectToAction("faq", "home");
                }
                else if (user.UserTypeId == (int)UserTypeEnum.ServiceProvider)
                {
                    RedirectToAction("contect", "home");
                }
                else
                {
                    RedirectToAction("Prices", "home");
                }
            }
            else
            {

            }
            ModelState.AddModelError("", "invalid Email or paswword");
            return View("index");
        }


    }
}