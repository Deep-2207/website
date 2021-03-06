using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.Repository;
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
        private readonly IAccountRepository _accountRepository;
        private readonly string _key = "HELPERLAND";
        private User _user;
        public AccountController(HelperlandContext helperlandContext,
                                    IDataProtectionProvider dataProtectionProvider,
                                    IConfiguration configuration,
                                    IAccountRepository accountRepository)
        {
            this._helperlandContext = helperlandContext;
            this._dataProtectionProvider = dataProtectionProvider;
            this._configuration = configuration;
            this._accountRepository = accountRepository;
            this._user = new User();
        }

        #region Create Account
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
                    IsApproved = true,
                    IsActive = true
                };

                _accountRepository.UpdateUser(user);
                TempData["Message"] = "Account Created Successfully";
                return RedirectToAction();
            }
            return View();
        }
        #endregion Create Account

        #region Become a provider
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
                    IsApproved = false,
                    UserProfilePicture = "/img/service-provider/avatar-hat.png",
                    IsActive = true
                    
                };

                _accountRepository.UpdateUser(user);
                TempData["Message"] = "Register successfully...!! When Admin can approve your Request then you can login";
                return RedirectToAction();
            }
            return View();
        }
        #endregion Become a provider

        #region LOgin and forgot password
        [HttpPost]
        public JsonResult login([FromBody] LoginViewModel model)
        {
            //User user = await _helperlandContext.Users.FindAsync(x => x.Email == model.Email && x.Password == model.Password);
            User user = _accountRepository.GetLoginuser(model.Email, model.Password);
            if (user != null && user.IsApproved == true && user.IsActive == true)
            {
              
                if (model.IsRemember == true)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMonths(1));
                    HttpContext.Response.Cookies.Append("EmailId", user.Email);
                    HttpContext.Response.Cookies.Append("Password", user.Password);
                }

                SessionUser sessionUser = new SessionUser()
                {
                    UserID = user.UserId,
                    UserName = user.FirstName + " " + user.LastName,
                    UserType = ((UserTypeEnum)user.UserTypeId).ToString(),
                    Email = model.Email
                };
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(sessionUser));

                if (user.UserTypeId == (int)UserTypeEnum.Customer)
                {
                    return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "OK", ErrorMessage = "", URL = "Customer/ServiceHistory" });
                }
                else if (user.UserTypeId == (int)UserTypeEnum.ServiceProvider)
                {
                    return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "OK", ErrorMessage = "", URL = "ServiceProvider/NewServiceRequest" });
                }
                else
                {
                    return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "OK", ErrorMessage = "", URL = "Admin/UserManagement" });
                }

            }
            else if (user != null && user.IsApproved == false && user.IsActive == true)
            {
                return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "Error", ErrorMessage = "Still Admin can not accept your Request" });
            }
            else if (user != null && user.IsApproved == true && user.IsActive == false)
            {
                return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "Error", ErrorMessage = "You are InActive By Admin Please Contact Admin User..!" });
            }
            else
            {
                return Json(new SingleEntity<LoginViewModel> { Result = model, Status = "Error", ErrorMessage = "Invalid UserName and Password" });
            }

            // return Json(new SingleEntity<LoginViewModel> { Result = model,Status="OK", ErrorMessage=""});
        }

        [HttpPost]
        public JsonResult forgotpassword([FromBody] ForgotViewModel model)
        {
            User user = _accountRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(user.Password);
                var OldPassword = System.Convert.ToBase64String(plaintextbytes);

                string input = model.Email + "_!_" + DateTime.Now.ToString() + "_!_" + OldPassword;


                var protector = _dataProtectionProvider.CreateProtector(_key);
                string encrypt = protector.Protect(input);

                EmailModel emailModel = new EmailModel
                {
                    To = model.Email,
                    Subject = "Helperland Reset Password",
                    Body = "Your reset link is" + "<a  href ='" + "http://" + this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt
                   
                };

                MailHelper mailhelper = new MailHelper(_configuration);

                mailhelper.Send(emailModel);
                return Json(new SingleEntity<ForgotViewModel> { Result = model, Status = "OK", ErrorMessage = "" });
            }
            else
            {
                return Json(new SingleEntity<ForgotViewModel> { Result = model, Status = "Error", ErrorMessage = "Please Enter the Registrated Email" });
            }

        }

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
            _user = _accountRepository.GetUserByEmail(resetpasswordToken[0]);

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

                _accountRepository.UpdateUser(_user);
            }
            return View();
        }

        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");

        }

        #endregion LOgin and forgot password

        #region Booke services
        public IActionResult Book_Services()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Book_Services(BookService model)
        {
            return View(model);
        }
        #endregion Booke services
    }
}