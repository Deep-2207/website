using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.Repository;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [CookiesHelper]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HelperlandContext _helperlandContext;
        private readonly IConfiguration _configuration;
        private readonly ICityRepository _cityRepostiory;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IServiceRequestExtraRepository _serviceRequestExtraRepository;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IServiceRequestAddressRepository _serviceRequestAddressRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private User _user;

        public HomeController(ILogger<HomeController> logger,
                                 IHostingEnvironment hostingEnvironment,
                                 HelperlandContext helperlandContext,
                                 IConfiguration configuration,
                                 ICityRepository cityRepostiory,
                                 IUserAddressRepository userAddressRepository,
                                 IServiceRequestExtraRepository serviceRequestExtraRepository,
                                 IServiceRequestRepository serviceRequestRepository,
                                 IServiceRequestAddressRepository serviceRequestAddressRepository,
                                 IStateRepository stateRepository)
        {
            _logger = logger;
            this._helperlandContext = helperlandContext;
            this._configuration = configuration;
            this._cityRepostiory = cityRepostiory;
            this._userAddressRepository = userAddressRepository;
            this._serviceRequestExtraRepository = serviceRequestExtraRepository;
            this._serviceRequestRepository = serviceRequestRepository;
            this._serviceRequestAddressRepository = serviceRequestAddressRepository;
            this._stateRepository = stateRepository;
            this._hostingEnvironment = hostingEnvironment;
            this._user = new User();
        }

        public IActionResult Index()
        {
            var Email = HttpContext.Request.Cookies["EmailId"];
            //var Password = HttpContext.Request.Cookies["Password"];

            if (Email != null)
            {
                _user = _helperlandContext.Users.Where(x => x.Email == Email).FirstOrDefault();
                HttpContext.Session.SetInt32("UserType", _user.UserTypeId);
                HttpContext.Session.SetString("UserName", _user.FirstName);

                if (_user.UserTypeId == (int)UserTypeEnum.Customer)
                    return RedirectToAction("Dashboard", "customer");
                else if (_user.UserTypeId == (int)UserTypeEnum.ServiceProvider)
                    return RedirectToAction("upcomingservice", "serviceprovider");
                else
                    return RedirectToAction("UserManagement", "admin");
                //userTypewiseRedirection(user.UserTypeId, user.F
            }
            else
            {
                ViewBag.page = "home";
                return View();
            }

        }

        public IActionResult homeindex()
        {
            ViewBag.page = "home";
            return View("~/views/home/index.cshtml");
        }

        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string filepath = "";
                string filename = "";
                if (model.attachment != null)
                {
                    string UploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload\\contact-us-attachment");
                    filename = Guid.NewGuid().ToString() + "_" + model.attachment.FileName;
                    filepath = Path.Combine(UploadsFolder, filename);
                    //model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        model.attachment.CopyTo(fileStream);
                    }

                }
                ContactU Newcontact = new ContactU()
                {
                    Name = model.firstname + " " + model.lastname,
                    Email = model.email,
                    Subject = model.subject,
                    PhoneNumber = model.mobileno,
                    Message = model.message,
                    UploadFileName = filename
                };
                _helperlandContext.Add(Newcontact);
                _helperlandContext.SaveChanges();


                EmailModel emailmodel = new EmailModel
                {
                    From = "",
                    To = "",
                    Subject = Newcontact.Subject,
                    Body = Newcontact.Message,
                    Attachment = filepath  /*Newcontact.UploadFileName*/
                };

                MailHelper mailhelp = new MailHelper(_configuration);

                mailhelp.SendContectUs(emailmodel);

                return RedirectToAction();
            }
            return View();
        }

        //[SessionHelper(UserTypeEnum.Customer)]
        [HttpGet]
        public IActionResult Book_Services()
        {
            var user = HttpContext.Session.GetString("User");
            if (user != null)
            {
                return View();
            }
            else
            {
                ViewBag.openmodel = true;
                ViewBag.page = "home";
                //return View(~/)
                return View("~/Views/Home/index.cshtml");
            }

            //if (checksessionuser(user))
            //{

            //    return View();
            //}
            //else
            //{
            //    ViewBag.openmodel = true;
            //    return RedirectToAction("Book_Services","home");
            //}

        }
        //public bool checksessionuser(string check)
        //{
        //    var IsUser = false;

        //    if (check != null)
        //    {
        //       return (IsUser = true);
        //    }
        //    return (IsUser = false);

        //}
        //[HttpPost]
        //public IActionResult Book_Services()
        //{
        //    //return View(model);
        //    //if(ViewBag.nextpage == true)
        //    //{
        //    //    return 
        //    //}

        //    return View("Schedule_Plan", "home");
        //    //return RedirectToAction("Book_Services", new { t = "pills-profile-tab" });
        //}
        //[HttpPost]
        //public IActionResult Schedule_Plan(LoginAndForgotPassword model)
        //{
        //    return View("Details", "home");
        //}


        [HttpPost]
        public JsonResult CheckPostalCode(string postalcode)
        {
            _user = _helperlandContext.Users.Where(x => x.ZipCode == postalcode).FirstOrDefault();
            bool IsPostalValid = false;
            if (_user != null)
            {
                IsPostalValid = true;
            }
            return Json(IsPostalValid);
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsPostalCodeValid(string CheckPostalCode)
        {
            var user = await _helperlandContext.Zipcodes.FirstOrDefaultAsync(x => x.ZipcodeValue == CheckPostalCode);

            if (user != null)
            {
                //return RedirectToAction("Book_Services", new { t = "pills-profile-tab" });
                ViewBag.nextpage = true;
                return RedirectToAction("Schedule_Plan", "home");
            }
            else
            {
                return Json($"The Postal Code Is not Valid");
            }
        }
        [HttpPost]
        public IActionResult btnclose()
        {
            return View("~/Views/Home/index.cshtml");
        }

        [HttpPost]
        public IActionResult ExtraServices(string ServiceName)
        {

            return View();
        }
        //public JsonResult checkNewAddress(string streetName, int house_number, int city, long phone_Number, UserAddress model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = HttpContext.Session.GetString("User");
        //        UserAddress userAddress = new UserAddress()
        //        {

        //        };
        //        return Json(true);
        //    }
        //    return Json(true);
        //}


        //public IActionResult CreateNewAddress(UserAddress model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = HttpContext.Session.GetString("User");
        //        UserAddress userAddress = new UserAddress()
        //        {
        //            UserId = model.UserId,
        //            AddressLine1 = model.AddressLine1,
        //            AddressLine2 = model.AddressLine2,
        //            PostalCode = model.PostalCode,
        //            City = model.City,
        //            Mobile = model.Mobile
        //        };

        //        _helperlandContext.UserAddresses.Add(model);
        //        _helperlandContext.SaveChanges();
        //        return View("~/Views/home/Book_Services.cshtml");

        //    }
        //    return View();
        //}

        [HttpPost]
        public JsonResult AddCustomerUserAddress([FromBody] UserAddressViewModel userAddressViewModel)
        {
            State state = _stateRepository.GetStateName(userAddressViewModel.City.ToString().Trim());
            UserAddress userAddress = new UserAddress
            {
                AddressLine1 = userAddressViewModel.StreetName.ToString().Trim(),
                AddressLine2 = userAddressViewModel.HouseNumber.ToString().Trim(),
                PostalCode = userAddressViewModel.PostalCode,
                City = userAddressViewModel.City.ToString().Trim(),
                State = state.StateName,
                Mobile = userAddressViewModel.MobileNumber,
                UserId = Convert.ToInt32(userAddressViewModel.UserID)
            };

            userAddress = _userAddressRepository.AddUserAddress(userAddress);

            return Json(userAddress);
        }


        //[HttpPost]
        //public JsonResult Completbooking([FromBody] UserAddressViewModel userAddressViewModel)
        //{
        //    UserAddress userAddress = new UserAddress
        //    {
        //        AddressLine1 = userAddressViewModel.StreetName,
        //        AddressLine2 = userAddressViewModel.HouseNumber,
        //        PostalCode = userAddressViewModel.PostalCode,
        //        City = userAddressViewModel.City,
        //        Mobile = userAddressViewModel.MobileNumber,
        //        UserId = Convert.ToInt32(userAddressViewModel.UserID)
        //    };

        //    userAddress = _userAddressRepository.AddUserAddress(userAddress);
        //    return Json(userAddress);
        //}
        [HttpPost]
        public JsonResult Completbooking([FromBody] ServiceRequestViewModel model)
        {
            ServiceRequest serviceRequest = new ServiceRequest
            {
                UserId = Convert.ToInt32(model.UserId),
                ServiceId = 0,
                ServiceStartDate = Convert.ToDateTime(model.ServiceStartDate.ToString().Trim() + " " + model.ServiceStarttime.ToString().Trim()),
                ZipCode = model.ZipCode.ToString().Trim(),
                ServiceHourlyRate = Convert.ToInt32(model.ServiceHourlyRate),
                ServiceHours = Convert.ToInt32(model.ServiceHours),
                ExtraHours = Convert.ToDouble(model.ExtraHours),
                SubTotal = Convert.ToDecimal(model.SubTotal),
                TotalCost = Convert.ToDecimal(model.TotalCost),
                Comments = model.Comments.ToString().Trim(),
                PaymentDone = false,
                Status = (int)ServiceStatusEnum.New,
                HasPets = model.HasPets,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                // ModifiedBy = model.UserId,
                RecordVersion = Guid.NewGuid(),
                Distance = 25,



            };
            _serviceRequestRepository.Add(serviceRequest);
            model.ServiceRequestID = serviceRequest.ServiceRequestId;

            UserAddress userAddress = _userAddressRepository.SelectAddressByID(Convert.ToInt32(model.UserAddressID));

            //    EmailModel emailModel = new EmailModel
            //    {
            //        //To = model.Forgot.Email,
            //       //foreach (var spuser  in model.T)
            //        Subject = "Helperland Reset Password",
            //        Body = "Your reset link is" + "<a  href ='" + "http://" + this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt


            //    };

            //MailHelper mailhelper = new MailHelper(_configuration);

            //mailhelper.Send(emailModel);


            ServiceRequestAddress serviceRequestAddress = new ServiceRequestAddress
            {
                ServiceRequestId = serviceRequest.ServiceRequestId,
                AddressLine1 = userAddress.AddressLine1,
                AddressLine2 = userAddress.AddressLine2,
                PostalCode = userAddress.PostalCode,
                City = userAddress.City,
                State = userAddress.State,
                Mobile = userAddress.Mobile,
                Email = userAddress.Email
            };
            _serviceRequestAddressRepository.Add(serviceRequestAddress);

            ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra
            {

                ServiceRequestId = serviceRequest.ServiceRequestId,

            };

           

            


            foreach (string extraService in model.ExtraservicesName)
            {
                serviceRequestExtra.ServiceRequestExtraId = 0;
                serviceRequestExtra.ServiceExtraId = Convert.ToInt32((ExtraServiceEnum)System.Enum.Parse(typeof(ExtraServiceEnum), extraService));
                _serviceRequestExtraRepository.Add(serviceRequestExtra);

            }
                List<User> sp = _helperlandContext.Users.Where(x => x.ZipCode == serviceRequest.ZipCode && x.IsApproved == true && x.UserTypeId == (int)UserTypeEnum.ServiceProvider).ToList();
            
                //List<User> sp = _helperlandContext.Users.Where(x => x.ZipCode == serviceRequest.ZipCode && x.IsApproved == true && x.UserTypeId == (int)UserTypeEnum.ServiceProvider && x.WorksWithPets == true).ToList();
            
            EmailModel emailModel;
            foreach (var spsendmail in sp)
            {
                emailModel = new EmailModel();
                emailModel.To = spsendmail.Email;
                emailModel.Subject = "Service AVailiblity";
                emailModel.Body = "Service ID " + serviceRequest.ServiceRequestId;
                ////Body =  "<a href = '" + this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt + "' > Reset Password </ a > "
                //Body = string.Format("Click <a href='{0}'>here</a> to login", this.Request.Host.ToString() + "/Account/ResetPassword?token=" + encrypt)
                MailHelper mailhelper = new MailHelper(_configuration);
                mailhelper.Send(emailModel);
            }

            return Json(model);

        }

        public JsonResult FillCityDropdown(string postalcode)
        {
            List<City> cities = _cityRepostiory.FillCityDropDown(postalcode);
            return Json(cities);

        }

        public IActionResult GetAddressByUserID(int userid)
        {
            List<UserAddress> address = _userAddressRepository.GetAllAddress(userid);
            return View("CustomerAddressList", address);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
