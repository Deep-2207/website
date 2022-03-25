using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Helperland.Repository;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [SessionHelper(userType: UserTypeEnum.Admin)]
    public class AdminController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        private readonly IAdminRepository _adminRepository;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;

        public AdminController(HelperlandContext helperlandContext ,
                                IAdminRepository adminRepository,
                                IConfiguration configuration,
                                ICustomerRepository customerRepository)
        {
            this._helperlandContext = helperlandContext;
            this._adminRepository = adminRepository;
            this._configuration = configuration;
            this._customerRepository = customerRepository;
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
            return View();
        }
        public IActionResult UserManagement()
        {
            return View();
        }
        public JsonResult getallrequest()
        {
            //var totallist = _adminRepository.allservicerequest();
            //return Json(totallist);
            var allservicerequest = (from sr in _helperlandContext.ServiceRequests
                                     join sradres in _helperlandContext.ServiceRequestAddresses
                                     on sr.ServiceRequestId equals sradres.ServiceRequestId
                                     select new
                                     {
                                         servicerequestid = sr.ServiceRequestId,
                                         servicestartdate = sr.ServiceStartDate,
                                         servicehours = sr.ServiceHours,
                                         customeruser = _helperlandContext.Users.Where(x => x.UserId == sr.UserId).FirstOrDefault(),
                                         serviceprovideruser = _helperlandContext.Users.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault(),
                                         ratings =(decimal?) _helperlandContext.Ratings.Where(x => x.RatingTo == sr.ServiceProviderId).Average(x => x.Ratings),
                                         status = sr.Status,
                                         customeraddress1 = sradres.AddressLine1 + " " + sradres.AddressLine2,
                                         customeraddress2 = sradres.PostalCode + " " + sradres.City,
                                     }).AsNoTracking().ToList();
            return Json(allservicerequest);

        }
        public JsonResult newuser()
        {
            var newuser = _adminRepository.allnewuser();
            return Json(newuser);
        }
        public IActionResult Servicerequest()
        {
            return View();
        }
        public JsonResult editrequest(int servicerequestid)
        {
            //var servicerequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == servicerequestid).Include(x => x.ServiceRequestAddresses).FirstOrDefault();
            var servicerequest = (from sr in _helperlandContext.ServiceRequests
                                  where sr.ServiceRequestId == servicerequestid
                                  select new
                                  {
                                     starttimeanddate = sr.ServiceStartDate,
                                     servicehourse = sr.ServiceHours,
                                     serviceaddress = _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == servicerequestid).FirstOrDefault()
                                  }).FirstOrDefault();
            return Json(servicerequest);
        }
        //public JsonResult login([FromBody] LoginViewModel model)
        public JsonResult editandreschedul([FromBody] AdminEditAndRescheduleViewModel model)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            ServiceRequest serviceRequest = _customerRepository.GetserviceReqestDetials(model.servicerequestid);

            List<ServiceRequest> serviceproviderrequest = _customerRepository.GetAllserviceBySPID(serviceRequest.ServiceProviderId);
            DateTime newdatetime = Convert.ToDateTime(model.startDate + " " + model.StartTime);
            DateTime newdatetimewithservicehours = newdatetime.AddMinutes(serviceRequest.ServiceHours * 60);
            //DateTime newtime = Convert.ToDateTime(chanhgetime);
            bool serviceRequestConflict = false;
            bool serviceovertime = true;
            DateTime dateLimit = Convert.ToDateTime(model.startDate).AddHours(21);

            if (newdatetimewithservicehours > dateLimit)
            {
                // return Json(new SingeEntity<ServiceRequestViewModel> { Result = model, Status = "Error", ErrorMessage = "Could not completed the service request, because service booking request is must be completed within 21:00 time" });
                serviceovertime = false;

            }

            foreach (var timecheck in serviceproviderrequest)
            {
                if (timecheck.ServiceRequestId != model.servicerequestid)
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
                serviceRequest.ServiceStartDate = Convert.ToDateTime(model.startDate + " " + model.StartTime.ToString().Trim());
                serviceRequest.ModifiedBy = sessionUser.UserID;
                serviceRequest.ModifiedDate = DateTime.Now;
                serviceRequest.Comments = model.comment;

                var address = _adminRepository.GetServicerequestAddress(model.servicerequestid);
                address.AddressLine1 = model.Streetname;
                address.AddressLine2 = model.HouseNumber;
                address.PostalCode = model.postalcode;
                address.City = model.city;

                _adminRepository.Updateservicerequest(serviceRequest);
                _adminRepository.UpdateServicerequestAddress(address);

                var eamilsend = (from sr in _helperlandContext.ServiceRequests
                                 join
                                 usermail in _helperlandContext.Users
                                 on sr.UserId equals usermail.UserId
                                 join
                                 spemail in _helperlandContext.Users
                                 on sr.ServiceProviderId equals spemail.UserId into tempsp
                                 from temptempsp in tempsp.DefaultIfEmpty()
                                 where sr.ServiceRequestId == model.servicerequestid
                                 select new
                                 {
                                     getuseremail = usermail.Email,
                                     getspemail = temptempsp.Email,

                                 }).AsNoTracking().ToList();


                EmailModel emailModel = new EmailModel();
                string tempmail = "";
                foreach (var spsendmail in eamilsend)
                {

                    tempmail += spsendmail.getuseremail;
                    if (spsendmail.getspemail != null)
                    {
                        tempmail += ",";
                        tempmail += spsendmail.getspemail;
                    }
                    

                    tempmail += spsendmail.getuseremail;


                }
               
                emailModel.To = tempmail;
               // emailModel.To = stremails;
                emailModel.Subject = "Serivcer Reschedul ";
                emailModel.Body = "Service ID " + serviceRequest.ServiceRequestId + " By Admin And <br/> New Time And Date is" + model.startDate + "-" + model.StartTime;

                MailHelper mailhelper = new MailHelper(_configuration);
                mailhelper.Send(emailModel);
            }
            var JsonData = new { serviceRequestConflict, serviceovertime };
            return Json(JsonData);

        }

        public JsonResult cancelservcierequest(int serviceid)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            var servicerequest = _customerRepository.GetserviceReqestDetials(serviceid);
            servicerequest.Status = (int)ServiceStatusEnum.Cancel;
            servicerequest.ModifiedBy = sessionUser.UserID;
            servicerequest.ModifiedDate = DateTime.Now;

            _adminRepository.Updateservicerequest(servicerequest);

            var eamilsend = (from sr in _helperlandContext.ServiceRequests
                             join
                             usermail in _helperlandContext.Users
                             on sr.UserId equals usermail.UserId
                             join
                             spemail in _helperlandContext.Users
                             on sr.ServiceProviderId equals spemail.UserId into tempsp
                             from temptempsp in tempsp.DefaultIfEmpty()
                             where sr.ServiceRequestId == serviceid
                             select new
                             {
                                 getuseremail = usermail.Email,
                                 getspemail = temptempsp.Email,

                             }).AsNoTracking().ToList();


            EmailModel emailModel = new EmailModel();
            string tempmail = "";
            foreach (var spsendmail in eamilsend)
            {

                tempmail += spsendmail.getuseremail;
                if (spsendmail.getspemail != null)
                {
                    tempmail += ",";
                    tempmail += spsendmail.getspemail;
                }


                tempmail += spsendmail.getuseremail;


            }

            emailModel.To = tempmail;
            // emailModel.To = stremails;
            emailModel.Subject = "Serivcer Cancelled";
            emailModel.Body = "Service ID " + serviceid + "is Cancelled By Admin";

            MailHelper mailhelper = new MailHelper(_configuration);
            mailhelper.Send(emailModel);

            return Json(servicerequest);
        }

        public JsonResult approve(int userid)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            User loginuser = _customerRepository.GetUSerbyloginid(userid);
            loginuser.IsApproved = true;
            loginuser.ModifiedBy = sessionUser.UserID;
            loginuser.ModifiedDate = DateTime.Now;

            _customerRepository.UpdateUserDetils(loginuser);

            return Json(loginuser);
        }
        public JsonResult activedeactive(int userid,int index)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            User loginuser = _customerRepository.GetUSerbyloginid(userid); ;

            if (index == 0)
            {
                loginuser.IsActive = true;
            }
            else
            {
                loginuser.IsActive = false;
            }
            loginuser.ModifiedBy = sessionUser.UserID;
            loginuser.ModifiedDate = DateTime.Now;
            _customerRepository.UpdateUserDetils(loginuser);
            return Json(loginuser);
        }
        public JsonResult searchusername(string searchTerm)
        {
            var users = _adminRepository.GetAllUserList();
            if (searchTerm != null)
            {
                users = _adminRepository.GetAllUserBySearch(searchTerm);
            }
            var modifieddata = users.Select(x => new
            {
                id = x.FirstName + " " + x.LastName,
                text = x.FirstName + " " + x.LastName
            }).Distinct();
            return Json(modifieddata);
        }
        public JsonResult searchcustomer(string searchTerm)
        {
            var users = _adminRepository.GetUserByTypeId(1);
            if (searchTerm != null)
            {
                users = _adminRepository.GetAllCustomerBySearch(searchTerm);
            }
            var modifieddata = users.Select(x => new
            {
                id = x.FirstName + " " + x.LastName,
                text = x.FirstName + " " + x.LastName
            }).Distinct();
            return Json(modifieddata);
        }
        public JsonResult searchserviceprovider(string searchTerm)
        {
            if(searchTerm != null)
            {
                var users = _adminRepository.GetAllServiceprovider();

                users = _adminRepository.GetAllServiceproviderBySearch(searchTerm);

                var modifieddata = users.Select(x => new
                {
                    id = x.FirstName + " " + x.LastName,
                    text = x.FirstName + " " + x.LastName
                }).Distinct();
                return Json(modifieddata);
            }
            else
            {
                return Json("");
            }
        }
        public JsonResult refundservice(int serviceid)
        {
            return Json(_helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceid).FirstOrDefault());
        }
        public JsonResult refundservicepost([FromBody] ServiceRequestViewModel model)
        {
            var servicrequest = _customerRepository.GetserviceReqestDetials(model.ServiceRequestID);
            servicrequest.RefundedAmount = model.Refundamount;
            servicrequest.ModifiedBy = getLoggedinUserId();
            servicrequest.ModifiedDate = DateTime.Now;
            servicrequest.Comments = model.Comments;

            _adminRepository.Updateservicerequest(servicrequest);

            return Json(servicrequest);

        }
    }
}
