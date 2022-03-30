using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.Repository;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Helperland.Controllers
{
    [CookiesHelper]
    [SessionHelper(userType: UserTypeEnum.Customer)]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly HelperlandContext _helperlandContext;
        private readonly IConfiguration _configuration;

        public CustomerController(ICustomerRepository customerRepository,
                                    ICityRepository cityRepository,
                                    IUserAddressRepository userAddressRepository,
                                    HelperlandContext helperlandContext,
                                    IConfiguration configuration)
        {
            this._customerRepository = customerRepository;
            this._cityRepository = cityRepository;
            this._userAddressRepository = userAddressRepository;
            this._helperlandContext = helperlandContext;
            this._configuration = configuration;
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

        #region customer Dashboard
        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            List<ServiceRequest> services = _customerRepository.GetAllServicebyUserid(sessionUser.UserID);
            return View(services);
        }

       
        public JsonResult dispaydataformtheserviceid(int servicerequestid)
        {
            var user = _customerRepository.GetserviceReqestDetials(servicerequestid);
            user.ServiceRequestExtras = _customerRepository.GetExtraservicesByServiceid(servicerequestid);
            user.ServiceRequestAddresses = _customerRepository.GetServicerequestAddress(servicerequestid);
            user.User = _customerRepository.GetUSerbyloginid(user.UserId);
            // user.User = _helperlandContext.Users.Where(x=>x.)

            String serviceRequestExtraName = "";

            foreach (ServiceRequestExtra serviceRequestExtra in user.ServiceRequestExtras)
            {
                serviceRequestExtraName = serviceRequestExtraName + ", " + Enum.GetName(typeof(ExtraServiceEnum), serviceRequestExtra.ServiceExtraId);
            }

            if (serviceRequestExtraName.Length > 2)
            {
                serviceRequestExtraName = serviceRequestExtraName.Remove(0, 2);
            }
            else
            {
                serviceRequestExtraName = "-";

            }

            //return Json(user);
            var result = new { user, serviceRequestExtraName };
            return Json(result);
        }
        [HttpPost]
        public JsonResult reschukeservicedate(int servicerequestid)
        {
            var user = _customerRepository.GetserviceReqestDetials(servicerequestid);
            user.ServiceRequestExtras = _customerRepository.GetExtraservicesByServiceid(servicerequestid);

            return Json(user);
        }

        [HttpPost]
        public JsonResult changeservicetimedate(int servicerequestid, string changedate, string chanhgetime)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            //var user = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            ServiceRequest serviceRequest = _customerRepository.GetserviceReqestDetials(servicerequestid);

            List<ServiceRequest> serviceproviderrequest = _customerRepository.GetAllserviceBySPID(serviceRequest.ServiceProviderId);
            DateTime newdatetime = Convert.ToDateTime(changedate + " " + chanhgetime);
            DateTime newdatetimewithservicehours = newdatetime.AddMinutes(serviceRequest.ServiceHours * 60);
            //DateTime newtime = Convert.ToDateTime(chanhgetime);
            bool serviceRequestConflict = false;
            bool serviceovertime = true;
            DateTime dateLimit = Convert.ToDateTime(changedate).AddHours(21);

            if (newdatetimewithservicehours > dateLimit)
            {
                // return Json(new SingeEntity<ServiceRequestViewModel> { Result = model, Status = "Error", ErrorMessage = "Could not completed the service request, because service booking request is must be completed within 21:00 time" });
                serviceovertime = false;

            }

            foreach (var timecheck in serviceproviderrequest)
            {
                if (timecheck.ServiceRequestId != servicerequestid)
                {
                    if (timecheck.ServiceStartDate <= newdatetimewithservicehours && newdatetime <= timecheck.ServiceStartDate.AddMinutes(timecheck.ServiceHours * 60))
                    {
                        serviceRequestConflict = false;
                        break;
                    }
                    else
                    {
                        serviceRequestConflict = true;
                    }
                }
            }

            if (serviceRequestConflict == true)
            {
                serviceRequest.ServiceStartDate = Convert.ToDateTime(changedate + " " + chanhgetime.ToString().Trim());
                serviceRequest.ModifiedBy = (int)UserTypeEnum.Customer;
                serviceRequest.ModifiedDate = DateTime.Now;

                _helperlandContext.ServiceRequests.Update(serviceRequest);
                _helperlandContext.SaveChanges();

                var eamilsend = (from sr in _helperlandContext.ServiceRequests
                                 join u in _helperlandContext.Users on sr.UserId equals u.UserId
                                 join sp in _helperlandContext.Users on sr.ServiceProviderId equals sp.UserId into sp1
                                 from sp in sp1.DefaultIfEmpty()
                                 where sr.ServiceRequestId == servicerequestid
                                 select new
                                 {
                                     serviceProviderEmail = sp.Email,
                                     availableSps = (from u in _helperlandContext.Users
                                                     join fb in _helperlandContext.FavoriteAndBlockeds on u.UserId equals fb.UserId into fb1
                                                     from fb in fb1.DefaultIfEmpty()
                                                     where u.ZipCode == sr.ZipCode && u.IsApproved == true && u.UserTypeId == (int)UserTypeEnum.ServiceProvider && Convert.ToInt16(sessionUser.UserID) != fb.TargetUserId
                                                     select u.Email).ToList()
                                 }).ToList();


                EmailModel emailModel = new EmailModel();
                string stremails = "";
                var vCount = 0;
                foreach (var e in eamilsend)
                {
                    if (e.serviceProviderEmail != null)
                    {
                        stremails += e.serviceProviderEmail;
                    }
                    else
                    {
                        foreach (var sps in e.availableSps)
                        {
                            if (vCount == 0)
                            {
                                stremails += sps;
                                vCount++;
                            }
                            else
                            {
                                stremails += "," + sps;
                            }
                        }
                    }
                }
                //emailModel.To = tempmail;
                 emailModel.To = stremails;
                emailModel.Subject = "Serivcer Reschedul ";
                emailModel.Body = "Service ID " + serviceRequest.ServiceRequestId + "New Time and Date : <Strong>" + changedate + " "+ chanhgetime + "</Strong>";

                MailHelper mailhelper = new MailHelper(_configuration);
                mailhelper.Send(emailModel);

            }
            var JsonData = new { serviceRequestConflict, serviceovertime };
            return Json(JsonData);
        }

        public JsonResult cancelservice(int servicerequestid)
        {
            ServiceRequest serviceRequest = _customerRepository.GetserviceReqestDetials(servicerequestid);
            serviceRequest.Status = (int)ServiceStatusEnum.Cancel;
            serviceRequest.ModifiedBy = (int)UserTypeEnum.Customer;
            serviceRequest.ModifiedDate = DateTime.Now;

            _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();
            var eamilsend = (from sr in _helperlandContext.ServiceRequests
                             join u in _helperlandContext.Users on sr.UserId equals u.UserId
                             join sp in _helperlandContext.Users on sr.ServiceProviderId equals sp.UserId into sp1
                             from sp in sp1.DefaultIfEmpty()
                             where sr.ServiceRequestId == servicerequestid
                             select new
                             {
                                 serviceProviderEmail = sp.Email,
                                 availableSps = (from u in _helperlandContext.Users
                                                 join fb in _helperlandContext.FavoriteAndBlockeds on u.UserId equals fb.UserId into fb1
                                                 from fb in fb1.DefaultIfEmpty()
                                                 where u.ZipCode == sr.ZipCode && u.IsApproved == true && u.UserTypeId == (int)UserTypeEnum.ServiceProvider && getLoggedinUserId() != fb.TargetUserId
                                                 select u.Email).ToList()
                             }).ToList();


            EmailModel emailModel = new EmailModel();
            string stremails = "";
            var vCount = 0;
            foreach (var e in eamilsend)
            {
                if (e.serviceProviderEmail != null)
                {
                    stremails += e.serviceProviderEmail;
                }
                else
                {
                    foreach (var sps in e.availableSps)
                    {
                        if (vCount == 0)
                        {
                            stremails += sps;
                            vCount++;
                        }
                        else
                        {
                            stremails += "," + sps;
                        }
                    }
                }
            }
            //emailModel.To = tempmail;
            emailModel.To = stremails;
            emailModel.Subject = "Serivcer Cancel ";
            emailModel.Body = "Service ID " + serviceRequest.ServiceRequestId + " Is Cancelled";

            MailHelper mailhelper = new MailHelper(_configuration);
            mailhelper.Send(emailModel);

            return Json(serviceRequest);
        }
        #endregion customer Dashboard

        #region Servicehistory
        public IActionResult ServiceHistory()
        {
            return View();
        }
        public JsonResult loadtable(int userid)
        {
            List<ServiceRequest> serviceRequests = _customerRepository.GetServiceHistoryBySpID(userid);
            foreach (ServiceRequest s in serviceRequests)
            {
                if (s.ServiceProviderId != null)
                {
                    s.Ratings = _customerRepository.GetRatingsBySpid(s.ServiceProviderId, s.Status);
                    s.User = _customerRepository.Getserviceprovider(s.ServiceProviderId);
                }
            }



            return Json(serviceRequests);
        }

      
        public JsonResult ratesp(int servicerequestid, int userid, float serviceontimearrival, float serviceFriendly, float serviceQualityofservice)
        {

            ServiceRequest serviceRequest = _customerRepository.GetserviceReqestDetials(servicerequestid);
            Rating rating = _customerRepository.GetRatingForServicerequest(servicerequestid); 

            RatingViewModel ratingViewModel = new RatingViewModel();

            if (rating != null)
            {
                ratingViewModel.RatingId = rating.RatingId;
            }
            ratingViewModel.ServiceProvider =_customerRepository.Getserviceprovider(serviceRequest.ServiceProviderId);

            if (serviceRequest.Status == (int)ServiceStatusEnum.Cancel)
            {
                return Json(new SingleEntity<RatingViewModel> { Result = ratingViewModel, Status = "error", ErrorMessage = "Your Request is cancel" });
            }


            return Json(new SingleEntity<RatingViewModel> { Result = ratingViewModel, Status = "ok" });
        }

       
    
        public JsonResult submitratings(Rating model)
        {
            ServiceRequest sr = _customerRepository.GetserviceReqestDetials(model.ServiceRequestId);
            Rating rsp = new Rating()
            {
                ServiceRequestId = sr.ServiceRequestId,
                RatingFrom = model.RatingFrom,
                RatingTo = model.RatingTo,
                OnTimeArrival = model.OnTimeArrival,
                Friendly = model.OnTimeArrival,
                QualityOfService = model.QualityOfService,
                RatingDate = DateTime.Now,
                Ratings = model.Ratings,
                Comments = model.Comments

            };

            _customerRepository.AddRatings(rsp);

            return Json(model);
        }

        #endregion Servicehistory

        #region Customer my settings

        public IActionResult MySettings()
        {
            return View();
        }
        public JsonResult filldeitails(int userid)
        {
            var user = _customerRepository.GetUSerbyloginid(userid);

            return Json(user);
        }

        public JsonResult updatedetialsbyuserid(User model)
        {

            User user = _customerRepository.GetUSerbyloginid(model.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            user.Mobile = model.Mobile;
            user.DateOfBirth = model.DateOfBirth;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = model.UserId;
            user.LanguageId = model.LanguageId;

            _customerRepository.UpdateUserDetils(user);

            return Json(model);
        }

        [HttpPost]
        public JsonResult getcutomeraddress()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }

            List<UserAddress> userAddresses = _customerRepository.GetAllAddress(Convert.ToInt16(sessionUser.UserID));
            return Json(userAddresses);

        }
        [HttpPost]
        public JsonResult GetAddressDetialsbyid(int addressid)
        {
            return Json(_customerRepository.SelectAddressByID(addressid));
        }
        [HttpPost]
        public JsonResult GetAddressDetialsbyUserid(int userid)
        {
            UserAddress add = _customerRepository.SelectAddressByID(userid);
            return Json(add);
        }

        [HttpPost]
        public JsonResult UpdateaddressById([FromBody] UserAddressViewModel userAddressViewModel)
        {
            UserAddress userAddress = _customerRepository.SelectAddressByID(Convert.ToInt32(userAddressViewModel.Addressid));
            userAddress.AddressLine1 = userAddressViewModel.StreetName;
            userAddress.AddressLine2 = userAddressViewModel.HouseNumber;
            userAddress.Mobile = userAddressViewModel.MobileNumber;
            userAddress.City = userAddressViewModel.City;
            userAddress.PostalCode = userAddressViewModel.PostalCode;

            var updateuseraddress = _customerRepository.UpdateAddress(userAddress);

            return Json(updateuseraddress);
        }

        [HttpPost]
        public JsonResult deleteaddressByID(int addressid)
        {
            return Json(_customerRepository.DeleteAddress(addressid));
        }

        [HttpPost]
        public JsonResult checkingoldpassword(string password, int userid, string newpassword)
        {
            User user = _customerRepository.GetUSerbyloginid(userid);
            bool IsPasswordSame = false;
            if (user.Password == password)
            {
                IsPasswordSame = true;


                user.Password = newpassword;
                user.ModifiedBy = userid;
                user.ModifiedDate = DateTime.Now;



                _customerRepository.UpdateUserDetils(user);

                return Json(IsPasswordSame);


            }
            return Json(IsPasswordSame);
        }
        #endregion Customer my settings

        //Customer FavouriteAndBlockServiceProvider block
        public IActionResult FavouriteAndBlockServiceProvider()
        {
            return View();
        }
        public JsonResult getspforcust()
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
            var serviceprovider = (from sr in _helperlandContext.ServiceRequests
                                   join
                                   usr in _helperlandContext.Users
                                   on sr.ServiceProviderId equals usr.UserId
                                   join 
                                   fb in _helperlandContext.FavoriteAndBlockeds
                                   on
                                   (int?)sr.ServiceProviderId equals (int?)fb.TargetUserId into temp
                                   from fb in temp.DefaultIfEmpty()
                                   where sr.UserId == getLoggedinUserId()
                                   select new
                                   {
                                       spid = sr.ServiceProviderId,
                                       spprofile = usr.UserProfilePicture,
                                       spservicecount = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == sr.ServiceProviderId).Count(),
                                       spratings = (decimal?)_helperlandContext.Ratings.Where(x => x.RatingTo == sr.ServiceProviderId).Average(x => x.Ratings),
                                       spName = usr.FirstName + " " + usr.LastName,
                                       spblock = (bool?)fb.IsBlocked,
                                       spfav = (bool?)fb.IsFavorite
                                   }).Distinct().ToList();
            return Json(serviceprovider);
        }
        public JsonResult FavAndBlock([FromBody] BlockAndFavViewModel model)
        {
            FavoriteAndBlocked fb = _helperlandContext.FavoriteAndBlockeds.Where(x => x.UserId == getLoggedinUserId() && x.TargetUserId == model.ServiceProviderid).FirstOrDefault();

           
            if (fb != null)
            {
                fb.IsFavorite = model.isfav;
                fb.IsBlocked = model.isblock;
                fb.UserId = getLoggedinUserId();
                fb.TargetUserId = model.ServiceProviderid;
                _helperlandContext.FavoriteAndBlockeds.Update(fb);
            }
            else
            {
                FavoriteAndBlocked newfb = new FavoriteAndBlocked();
                newfb.IsFavorite = model.isfav;
                newfb.IsBlocked = model.isblock;
                newfb.UserId = getLoggedinUserId();
                newfb.TargetUserId = model.ServiceProviderid;
                _helperlandContext.FavoriteAndBlockeds.Add(newfb);
            }
            _helperlandContext.SaveChanges();

            return Json(model);
        }
    }
}