using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [CookiesHelper]
    public class AccountController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IConfiguration _configuration;
        private readonly string _key = "HELPERLAND";
        private User _user;
        public AccountController(HelperlandContext helperlandContext,
                                    IDataProtectionProvider dataProtectionProvider,
                                    IConfiguration configuration)
        {
            this._helperlandContext = helperlandContext;
            this._dataProtectionProvider = dataProtectionProvider;
            this._configuration = configuration;
            this._user = new User();
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
        public IActionResult BecomeAPro(CreateAccountViewModel model)
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
                    UserTypeId = (int)UserTypeEnum.ServiceProvider,
                    IsApproved = false
                };

                _helperlandContext.Add(user);
                _helperlandContext.SaveChanges();
                TempData["Message"] = "Register successfully...!! When Admin can approve your Request then you can login";
                return RedirectToAction();
            }
            return View();
        }
        [HttpGet]
        public IActionResult login(LoginViewModel model)
        {
            //if (model.IsRemember == true)
            //{
            //    CookieOptions cookieOptions = new CookieOptions();
            //    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(20));
            //    //cookieOptions.Domain = 

            //    HttpContext.Response.Cookies.Append("Email", model.Email, cookieOptions);
            //    //HttpContext.Response.Cookies.Append("Password", model.Password, cookieOptions);
            //}
            return View();
        }


        [HttpPost]
        //[Route("home/index")]
        public async Task<IActionResult> login(LoginAndForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                //User user = await _helperlandContext.Users.FindAsync(x => x.Email == model.Email && x.Password == model.Password);
                User user = await _helperlandContext.Users.FirstOrDefaultAsync(x => x.Email == model.Login.Email && x.Password == model.Login.Password);
                if (user != null && user.IsApproved == true)
                {
                    if (model.Login.IsRemember == true)
                    {
                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMonths(1));
                        HttpContext.Response.Cookies.Append("EmailId", user.Email);
                        //HttpContext.Response.Cookies.Append("Password", user.Password);
                    }

                    SessionUser sessionUser = new SessionUser()
                    {
                        UserID = user.UserId,
                        UserName = user.FirstName + " " + user.LastName,
                        UserType = ((UserTypeEnum)user.UserTypeId).ToString()
                    };
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(sessionUser));

                  


                    //return RedirectToAction("index", "Home");
                    if (user.UserTypeId == (int)UserTypeEnum.Customer)
                    {
                        if (TempData["BookService"] != "")
                        {
                            return RedirectToAction("Book_Services", "Home");
                        }
                        else
                        {
                            return RedirectToAction("ServiceHistory", "Customer");
                        }
                        
                    }
                    else if (user.UserTypeId == (int)UserTypeEnum.ServiceProvider)
                    {
                        return RedirectToAction("ServiceProviderView", "ServiceProvider");
                    }
                    else
                    {
                        return RedirectToAction("UserManagement", "Admin");
                    }
                }
                else if (user != null && user.IsApproved == false)
                {
                    TempData["ErrorMessage"] = "You have not yet received approval by the Admin";
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid USername and Password";
                }

            }

            ViewBag.page = "home";
            ViewBag.openmodel = true;
           return View("~/Views/home/index.cshtml",model);


        }

        //[HttpGet]
        //public IActionResult ResetPassword()
        //{
        //    return View();
        //}

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _helperlandContext.Users.FirstOrDefaultAsync(e => e.Email == email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }


        [HttpPost]
        public IActionResult ForgotPassword(LoginAndForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                User user = _helperlandContext.Users.Where(x => x.Email == model.Forgot.Email).FirstOrDefault();
                if (user != null)
                {
                    var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(user.Password);
                    var OldPassword = System.Convert.ToBase64String(plaintextbytes);

                    string input = model.Forgot.Email + "_!_" + DateTime.Now.ToString() + "_!_" + OldPassword;


                    var protector = _dataProtectionProvider.CreateProtector(_key);
                    string encrypt = protector.Protect(input);

                    EmailModel emailModel = new EmailModel
                    {
                        To = model.Forgot.Email,
                        Subject = "Helperland Reset Password",
                        Body = "Your reset link is" + "<a  href ='" + "http://" + this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt
                        //Body =  "<a href = '" + this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt + "' > Reset Password </ a > "
                        //Body = string.Format("Click <a href='{0}'>here</a> to login", this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt)
                    };

                    MailHelper mailhelper = new MailHelper(_configuration);

                    mailhelper.Send(emailModel);
                }
                ViewBag.ForgotPasswordResetLinksend = true;
                ViewBag.page = "home";
                //  TempData["data"] = "send";
                return View("~/Views/Home/index.cshtml");
            }
            return View();
        }


        public IActionResult ResetPassword(string token)
        {
            if (ModelState.IsValid)
            {
                if (token != null)
                {
                    CheckPassword(token);
                    return View();
                    

                }
            }
            return View();
        }

        public bool CheckPassword(string token)
        {
            string decrypt = "";
            try
            {
                var protector = _dataProtectionProvider.CreateProtector(_key);
                decrypt = protector.Unprotect(token);
            }
            catch
            {
                ViewBag.ErrorMessage = "Link is InValid";
                return true;
            }

            string[] resetpasswordToken = decrypt.Split("_!_");
            _user = _helperlandContext.Users.Where(x => x.Email == resetpasswordToken[0]).FirstOrDefault();

            DateTime tokendate = Convert.ToDateTime(resetpasswordToken[1]).AddMinutes(30);
            DateTime dateTime = DateTime.Now;

            var Base64EncodeBytes = System.Convert.FromBase64String(resetpasswordToken[2]);
            var oldPassword = System.Text.Encoding.UTF8.GetString(Base64EncodeBytes);

            if (tokendate < dateTime || oldPassword != _user.Password)
            {
                ViewBag.ErrorMessage = "Link is Expaired";
                return false;
            }
            return true;

        }


        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (!CheckPassword(model.Token))
                {
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Success";
                    ViewBag.Message = "true";
                }

                _user.Password = model.NewPassword;
                _user.ModifiedDate = DateTime.Now;

                // _user = _helperlandContext.Users.Where(x => x.Email == model.Email).FirstOrDefault();

                _helperlandContext.Users.Update(_user);
                // _helperlandContext.Update(_user);
                _helperlandContext.SaveChanges();
            }
            return View();
        }

        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys) {
                Response.Cookies.Delete(cookie);
            }
            
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
           
        }
        public IActionResult Book_Services()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Book_Services(BookService model)
        {
            return View(model);
        }
    }
}