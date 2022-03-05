using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.Repository;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Helperland.Controllers
{
    [CookiesHelper]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly HelperlandContext _helperlandContext;

        public CustomerController(ICustomerRepository customerRepository,
                                    ICityRepository cityRepository,
                                    IUserAddressRepository userAddressRepository,
                                    HelperlandContext helperlandContext)
        {
            this._customerRepository = customerRepository;
            this._cityRepository = cityRepository;
            this._userAddressRepository = userAddressRepository;
            this._helperlandContext = helperlandContext;
        }
        public IActionResult ServiceHistory()
        {
            return View();
        }
        public IActionResult BookService()
        {
            return View();
        }
        public IActionResult MySettings()
        {
            return View();
        }
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

        //public double CalculateAverageRating()
        //{
        //    var 
        //    return Convert.ToDouble(Ratings);
        //}



        public JsonResult dispaydataformtheserviceid(int servicerequestid)
        {


            var user = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            user.ServiceRequestExtras = _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == servicerequestid).ToList();
            user.ServiceRequestAddresses = _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == servicerequestid).ToList();
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
            var user = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            user.ServiceRequestExtras = _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == servicerequestid).ToList();

            return Json(user);
        }
        [HttpPost]
        public JsonResult changeservicetimedate(int servicerequestid, string changedate, string chanhgetime)
        {
            //var user = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();

            List<ServiceRequest> serviceproviderrequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == serviceRequest.ServiceProviderId).ToList();



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
                    //if (newdatetime == timecheck.ServiceStartDate)
                    //{
                    //    break;
                    //}
                    if (timecheck.ServiceStartDate <= newdatetimewithservicehours && newdatetime <= timecheck.ServiceStartDate.AddMinutes(timecheck.ServiceHours * 60))
                    {
                        serviceRequestConflict = false;
                        break;
                        //Json(new SingleEntity<LoginViewModel> { Result = model, Status = "OK", ErrorMessage = errorMessage = "Another service request has been assigned to the service provider on " + serviceRequestStartDateTime.ToShortDateString()
                        //    + " from " + serviceRequestStartDateTime.ToShortTimeString() + " to " + serviceRequestEndD, URL = "Customer/ServiceHistory" });
                        //return Json(serviceRequestConflict ,  
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
            }
            var JsonData = new { serviceRequestConflict, serviceovertime };
            return Json(JsonData);
        }

        public JsonResult cancelservice(int servicerequestid)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            serviceRequest.Status = (int)ServiceStatusEnum.Cancel;
            serviceRequest.ModifiedBy = (int)UserTypeEnum.Customer;
            serviceRequest.ModifiedDate = DateTime.Now;

            _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();

            return Json(serviceRequest);
        }


        //servicehistory page cs file start

        public JsonResult loadtable(int userid)
        {
            List<ServiceRequest> serviceRequests = _helperlandContext.ServiceRequests.Where(x => x.UserId == userid &&
                                                                                        x.Status == (int)ServiceStatusEnum.completed ||
                                                                                        x.Status == (int)ServiceStatusEnum.Cancel).ToList();
            foreach (ServiceRequest s in serviceRequests)
            {
                if (s.ServiceProviderId != null)
                {
                    s.Ratings = _helperlandContext.Ratings.Where(x => x.RatingTo == s.ServiceProviderId && s.Status != (int)ServiceStatusEnum.Cancel).ToList();
                    s.User = _helperlandContext.Users.Where(x => x.UserId == s.ServiceProviderId).FirstOrDefault();
                }
            }



            return Json(serviceRequests);
        }

        //float serviceontimearrival, float serviceFriendly, float serviceQualityofservice
        public JsonResult ratesp(int servicerequestid, int userid, float serviceontimearrival, float serviceFriendly, float serviceQualityofservice)
        {

            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();
            Rating rating = _helperlandContext.Ratings.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault();

            RatingViewModel ratingViewModel = new RatingViewModel();

            if (rating != null)
            {
                ratingViewModel.RatingId = rating.RatingId;
                //ratingViewModel.ServiceProviderRating = rating.OnTimeArrival


            }


            //Rating ratings = new Rating()
            //{
            //    ServiceRequestId = servicerequestid,
            //    RatingFrom = userid,
            //    RatingTo = userid

            //};

            ratingViewModel.ServiceProvider = _helperlandContext.Users.Where(x => x.UserId == serviceRequest.ServiceProviderId).FirstOrDefault();

            if (serviceRequest.Status == (int)ServiceStatusEnum.Cancel)
            {
                return Json(new SingleEntity<RatingViewModel> { Result = ratingViewModel, Status = "error", ErrorMessage = "Your Request is cancel" });
            }


            return Json(new SingleEntity<RatingViewModel> { Result = ratingViewModel, Status = "ok" });
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

        //public JsonResult Getaddress(int userid)
        //{
        //    List<UserAddress> address = _userAddressRepository.GetAllAddress(userid);
        //    return Json(address);
        //}

        [HttpPost]
        public JsonResult getcutomeraddress()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }

            List<UserAddress> userAddresses = _userAddressRepository.GetAllAddress(Convert.ToInt16(sessionUser.UserID));
            return Json(userAddresses);

        }
        [HttpPost]
        public JsonResult GetAddressDetialsbyid(int addressid)
        {
            return Json(_userAddressRepository.SelectAddressByID(addressid));
        }

        [HttpPost]
        public JsonResult UpdateaddressById([FromBody] UserAddressViewModel userAddressViewModel)
        {
            UserAddress userAddress = _userAddressRepository.SelectAddressByID(Convert.ToInt32(userAddressViewModel.Addressid));
            userAddress.AddressLine1 = userAddressViewModel.StreetName;
            userAddress.AddressLine2 = userAddressViewModel.HouseNumber;
            userAddress.Mobile = userAddressViewModel.MobileNumber;
            userAddress.City = userAddressViewModel.City;
            userAddress.PostalCode = userAddressViewModel.PostalCode;

            var updateuseraddress = _userAddressRepository.UpdateAddress(userAddress);

            return Json(updateuseraddress);
        }

        [HttpPost]
        public JsonResult deleteaddressByID(int addressid)
        {
            return Json(_userAddressRepository.DeleteAddress(addressid));
        }

        [HttpPost]
        public JsonResult checkingoldpassword(string password, int userid, string newpassword)
        {
            User user = _helperlandContext.Users.Where(x => x.UserId == userid).FirstOrDefault();
            bool IsPasswordSame = false;
            if (user.Password == password)
            {
                IsPasswordSame = true;


                user.Password = newpassword;
                user.ModifiedBy = userid;
                user.ModifiedDate = DateTime.Now;



                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();

                return Json(IsPasswordSame);


            }
            return Json(IsPasswordSame);
        }

    }
}