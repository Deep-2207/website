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
using Newtonsoft.Json;
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
        public int getLoggedinUserId()
        {

            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            return sessionUser.UserID;
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
                    return RedirectToAction("UpcomingServices", "ServiceProvider");
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

        #region Contact us
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

        #endregion Contact us

        #region Book Service

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


        }


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

        [HttpPost]
        public JsonResult AddCustomerUserAddress([FromBody] UserAddressViewModel userAddressViewModel)
        {

            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }


            State state = _stateRepository.GetStateName(userAddressViewModel.City.ToString().Trim());
            UserAddress userAddress = new UserAddress
            {
                AddressLine1 = userAddressViewModel.StreetName.ToString().Trim(),
                AddressLine2 = userAddressViewModel.HouseNumber.ToString().Trim(),
                PostalCode = userAddressViewModel.PostalCode,
                City = userAddressViewModel.City.ToString().Trim(),
                State = state.StateName,
                Mobile = userAddressViewModel.MobileNumber,
                UserId = Convert.ToInt32(userAddressViewModel.UserID),
                Email = sessionUser.Email


            };

            userAddress = _userAddressRepository.AddUserAddress(userAddress);

            return Json(userAddress);
        }

        [HttpPost]
        public JsonResult Completbooking([FromBody] ServiceRequestViewModel model)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
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
            if (model.ServiceproviderId != 0)
            {
                serviceRequest.ServiceProviderId = model.ServiceproviderId;
            }
            _serviceRequestRepository.Add(serviceRequest);
            model.ServiceRequestID = serviceRequest.ServiceRequestId;

            UserAddress userAddress = _userAddressRepository.SelectAddressByID(Convert.ToInt32(model.UserAddressID));

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


            IEnumerable<User> sp1;

            if (model.ServiceproviderId != 0)
            {
                sp1 = (from usr in _helperlandContext.Users
                       where usr.UserId == model.ServiceproviderId
                       select usr).ToList();

            }
            else
            {

                sp1 = (from usr in _helperlandContext.Users
                       join
                       fb in _helperlandContext.FavoriteAndBlockeds
                       on
                       usr.UserId equals fb.TargetUserId into temp
                       from fb in temp.DefaultIfEmpty()
                       join
                       fb1 in _helperlandContext.FavoriteAndBlockeds
                       on
                       fb.TargetUserId equals fb1.UserId
                       into temp1
                       from fb1 in temp1.DefaultIfEmpty()
                       where usr.UserTypeId == (int)UserTypeEnum.ServiceProvider && usr.ZipCode == model.ZipCode && usr.IsApproved == true &&
                       (fb.UserId == sessionUser.UserID || fb.Equals(null)) &&
                       (fb.IsBlocked == false || fb.Equals(null))
                       && (fb1.IsBlocked == false || fb1.Equals(null))
                       select usr).ToList();


            }
            EmailModel emailModel = new EmailModel();
            string stremails = "";
            var vCount = 0;
            foreach (var e in sp1)
            {
                if (vCount == 0)
                {
                    stremails += e.Email;
                    vCount++;
                }
                else
                {
                    stremails += "," + e.Email;
                }
            }



            emailModel.To = stremails;
            emailModel.Subject = "Service AVailiblity";
            emailModel.Body = "Service ID " + serviceRequest.ServiceRequestId;

            MailHelper mailhelper = new MailHelper(_configuration);
            mailhelper.Send(emailModel);


            return Json(model);

        }

        public JsonResult FillCityDropdown(string postalcode)
        {
            List<City> cities = _cityRepostiory.FillCityDropDown(postalcode);
            return Json(cities);
        }

        public IActionResult GetAddressByUserID(int userid, string postalcode)
        {
            List<UserAddress> address = _userAddressRepository.GetAllAddressbypostalcode(userid, postalcode);
            return View("CustomerAddressList", address);
        }

        #endregion Book Service

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public JsonResult getfavsp(string zipcode)
        {
            //            select DISTINCT(ServiceProviderId), fb.IsFavorite,fb.IsBlocked from[dbo].[ServiceRequest] as sr
            //join
            //[dbo].[User] as usr
            //on
            //sr.ServiceProviderId = usr.UserId
            //left join
            //[dbo].[FavoriteAndBlocked] as fb
            //on
            //ISNULL(fb.TargetUserId, '`') = ISNULL(sr.ServiceProviderId, '`')
            //where sr.UserId = '24'

            //            select* from[dbo].[User] as usr
            //left join
            //[dbo].[FavoriteAndBlocked] as fb
            //on
            // usr.UserId = fb.TargetUserId
            //where
            //usr.UserTypeId = '2' AND
            //usr.ZipCode = '380001' AND
            //fb.UserId = 24 AND
            //fb.IsFavorite = 1
            var favsp = (from usr in _helperlandContext.Users
                         join fb in _helperlandContext.FavoriteAndBlockeds
                         on
                         usr.UserId equals fb.TargetUserId
                         into temp
                         from fb in temp.DefaultIfEmpty()
                         where usr.UserTypeId == (int)UserTypeEnum.ServiceProvider && usr.ZipCode == zipcode && usr.IsApproved == true &&
                         fb.UserId == getLoggedinUserId() && fb.IsFavorite == true
                         select new
                         {
                             spname = usr.FirstName + " " + usr.LastName,
                             spworkwithpet = usr.WorksWithPets,
                             spemail = usr.Email,
                             spprofile = usr.UserProfilePicture,
                             spid = usr.UserId
                         }).ToList();
            return Json(favsp);
        }

        public JsonResult checkconflictsp(int spid)
        {

            //            select* from[dbo].[FavoriteAndBlocked] as fb
            //where
            //fb.UserId = '1028' and fb.IsBlocked = 1 and fb.TargetUserId = 24
            var spconflickt = (from fb in _helperlandContext.FavoriteAndBlockeds
                               where fb.UserId == spid && fb.IsBlocked == true && fb.TargetUserId == getLoggedinUserId()
                               select fb
                               ).FirstOrDefault();
            bool spblock = false;
            if (spconflickt != null)
            {
                spblock = true;
                return Json(spblock);
            }
            return Json(spid);

        }
    }
}
