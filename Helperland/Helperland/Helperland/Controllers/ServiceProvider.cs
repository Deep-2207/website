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
    [SessionHelper(userType:UserTypeEnum.ServiceProvider)]
    public class ServiceProvider : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public ServiceProvider(HelperlandContext helperlandContext,
            IServiceProviderRepository serviceProviderRepository,
            IStateRepository stateRepository,
            ICustomerRepository customerRepository,
            IConfiguration configuration )
        {
            this._helperlandContext = helperlandContext;
            this._serviceProviderRepository = serviceProviderRepository;
            this._stateRepository = stateRepository;
            this._customerRepository = customerRepository;
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
        #region MYSettings
        public IActionResult Mysettings()
        {
            return View();
        }
        public JsonResult filldeitails(int userid)
        {
            var user = _customerRepository.GetUSerbyloginid(userid);

            return Json(user);
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
        public JsonResult addorupdateaddress(UserAddress model)
        {
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.UserId == model.UserId).FirstOrDefault();
           if(userAddress == null)
            {
                userAddress = new UserAddress();
            }
            userAddress.UserId = model.UserId;
            userAddress.AddressLine1 = model.AddressLine1;
            userAddress.AddressLine2 = model.AddressLine2;
            userAddress.City = model.City;
            userAddress.PostalCode = model.PostalCode;
            userAddress.Mobile = model.Mobile;
            userAddress.Email = model.Email;
            State state = _stateRepository.GetStateName(model.City.ToString().Trim());
            userAddress.State = state.StateName;
            if (userAddress.AddressId == 0)
            {
                _helperlandContext.UserAddresses.Add(userAddress);
                _helperlandContext.SaveChanges();
            }
            else
            {
                _helperlandContext.UserAddresses.Update(userAddress);
                _helperlandContext.SaveChanges();
            }
            return Json(model);
        }
        #endregion MYSettings

        #region New Servicerequest
        public IActionResult NewServiceRequest()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FillcheckboxHaspet()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            User sp = _serviceProviderRepository.GetHashPetAtHome(sessionUser.UserID);

            bool workingwithpet = Convert.ToBoolean(sp.WorksWithPets);
            return Json(workingwithpet);
        }
       

        public JsonResult getnewservicerequest(bool HasPat)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
           
            var servicedisapy = (from sr in _helperlandContext.ServiceRequests
                                                                        join
                                                                        usr in _helperlandContext.Users
                                                                        on sr.ZipCode equals usr.ZipCode
                                                                        join
                                                                        cuaddress in _helperlandContext.ServiceRequestAddresses
                                                                        on sr.ServiceRequestId equals cuaddress.ServiceRequestId
                                                                        join fb in _helperlandContext.FavoriteAndBlockeds on (int?)sessionUser.UserID equals (int?)fb.UserId into fb1
                                                                        from fb in fb1.DefaultIfEmpty()
                                                                        where usr.UserId == sessionUser.UserID && sr.Status == Convert.ToInt16(ServiceStatusEnum.New) && sr.ServiceProviderId == null && sr.HasPets == HasPat && (int?)fb.TargetUserId != (int?)sr.UserId
                                                                        select new
                                                                        {
                                                                            serviceid = sr.ServiceRequestId,
                                                                            servicestartdate = sr.ServiceStartDate,
                                                                            customeruser = _helperlandContext.Users.Where(x => x.UserId == sr.UserId).FirstOrDefault(),
                                                                            serviceaddressstrretname = cuaddress.AddressLine1,
                                                                            serviceaddresshousenumber = cuaddress.AddressLine2,
                                                                            servicereqestcity = cuaddress.City,
                                                                            servicereqestpostalcode = cuaddress.PostalCode,
                                                                            payment = sr.TotalCost,
                                                                            workingwithpet = HasPat,
                                                                            servicehoures = sr.ServiceHours,
                                                                            recordVersion = sr.RecordVersion
                                                                        }).Distinct();
            return Json(servicedisapy);

        }
        public JsonResult AcceptServicerequest(int serviceid, string recordVersion)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
           
            ServiceRequest newacceptrequest =_customerRepository.GetserviceReqestDetials(serviceid);

            bool RequestAccepted = true;
            if (newacceptrequest.RecordVersion.ToString() != recordVersion)
            {
                //return    error this service request assign to different user
                return Json(RequestAccepted = false);
            }

            List<ServiceRequest> oldsr = _serviceProviderRepository.listoldrequest(sessionUser.UserID);
            bool serviceRequestConflict = false;
            bool noLongerAvailable = true;
            foreach (var timecheck in oldsr)
            {
                DateTime newdatetime = Convert.ToDateTime(newacceptrequest.ServiceStartDate);
                DateTime newdatetimewithservicehours = newdatetime.AddMinutes(newacceptrequest.ServiceHours * 60);
                
                if (timecheck.ServiceRequestId != serviceid)
                {
                    if (timecheck.ServiceStartDate <= newdatetimewithservicehours && newdatetime <= timecheck.ServiceStartDate.AddMinutes((timecheck.ServiceHours * 60) + 30))
                    {
                        serviceRequestConflict = false;
                        return Json(new { timecheck.ServiceRequestId, serviceRequestConflict });
                    }
                    else
                    {
                        serviceRequestConflict = true;
                    }
                }
                newdatetime = DateTime.Now.Date;
                newdatetimewithservicehours = DateTime.Now.Date;
            }

            if (serviceRequestConflict == true)
            {
                if (_serviceProviderRepository.GetCountOfservicerequest(serviceid, (int)ServiceStatusEnum.New) == 1)
                {
                    ServiceRequest sr = _serviceProviderRepository.Detailsofsr(serviceid);
                    sr.ServiceProviderId = sessionUser.UserID;
                    sr.SpacceptedDate = DateTime.Now;
                    sr.Status = (int)ServiceStatusEnum.Pending;

                    _serviceProviderRepository.Updateservicerequest(sr);

                    var userList = (from sp in _helperlandContext.Users
                                           join fb in _helperlandContext.FavoriteAndBlockeds
                                           on sp.UserId equals fb.UserId into temp
                                           from fb in temp.DefaultIfEmpty()
                                    where sp.ZipCode == newacceptrequest.ZipCode && sp.UserId != newacceptrequest.ServiceProviderId && sp.UserTypeId == (int)UserTypeEnum.ServiceProvider && sp.IsApproved == true && newacceptrequest.UserId != fb.TargetUserId
                                    select sp.Email
                                           ).ToList();
                    EmailModel emailModel = new EmailModel();
                    string stremails = "";
                    var vCount = 0;
                    foreach (var e in userList)
                    {
                        if (vCount == 0)
                        {
                            stremails += e;
                            vCount++;
                        }
                        else
                        {
                            stremails += "," + e;
                        }
                    }
                    emailModel.To = stremails;
                    emailModel.Subject = "Service Request no more Available!";
                    emailModel.Body = "Service Request <strong>" + newacceptrequest.ServiceRequestId + "</strong> has already been accepted by someone and is no more available to You!";
                    MailHelper mailhelper = new MailHelper(_configuration);
                    mailhelper.Send(emailModel);
                }

            
                else
                {
                    return Json(new { noLongerAvailable });
                }

            }

            return Json(serviceRequestConflict);
        }
        #endregion New Servicerequest

        #region Upcoming servierequest
        public IActionResult UpcomingServices()
        {
            return View();
        }
        public JsonResult upcomingservice()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }


            var servicedisapy = (from sr in _helperlandContext.ServiceRequests
                                 join

                                cuaddress in _helperlandContext.ServiceRequestAddresses
                                    on sr.ServiceRequestId equals cuaddress.ServiceRequestId
                                 where sr.Status == Convert.ToInt16(ServiceStatusEnum.Pending) && sr.ServiceProviderId == sessionUser.UserID
                                 select new
                                 {
                                     serviceid = sr.ServiceRequestId,
                                     servicestartdate = sr.ServiceStartDate,
                                     customeruser = _helperlandContext.Users.Where(x => x.UserId == sr.UserId).FirstOrDefault(),
                                     serviceaddressstrretname = cuaddress.AddressLine1,
                                     serviceaddresshousenumber = cuaddress.AddressLine2,
                                     servicereqestcity = cuaddress.City,
                                     servicereqestpostalcode = cuaddress.PostalCode,
                                     payment = sr.TotalCost,
                                     servicehoures = sr.ServiceHours
                                 }).ToList();
            return Json(servicedisapy);

        }

        public JsonResult Completed(int serviceid)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            var comp = _serviceProviderRepository.completed(serviceid);
            comp.Status = (int)ServiceStatusEnum.completed;
            comp.ModifiedBy = sessionUser.UserID;
            comp.ModifiedDate = DateTime.Now;

            return Json(_serviceProviderRepository.Updateservicereqest(comp));

        }

        public JsonResult Cancel(int serviceid)
        {
           
            var comp = _serviceProviderRepository.completed(serviceid);
            comp.Status = (int)ServiceStatusEnum.Cancel;
            comp.ModifiedBy = getLoggedinUserId();
            comp.ModifiedDate = DateTime.Now;

            var email = _serviceProviderRepository.GetMailforTheuserid(comp.UserId);
            EmailModel emailModel = new EmailModel();
            
            emailModel.To = email;
            emailModel.Subject = "Service Request no more Available!";
            emailModel.Body = "Service Request <strong>" + comp.ServiceRequestId + "</strong> Is Canceled By The  By serviceprovider";
            MailHelper mailhelper = new MailHelper(_configuration);
            mailhelper.Send(emailModel);
            return Json(_serviceProviderRepository.Updateservicereqest(comp));
        }
        #endregion Upcoming servierequest

        #region Servicehistory
        public IActionResult ServiceHistory()
        {
            return View();
        }
        public JsonResult getservicehistory()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
            var servicedisapy = (from sr in _helperlandContext.ServiceRequests
                                 join
                                    usr in _helperlandContext.Users
                                    on sr.ZipCode equals usr.ZipCode
                                 join
                                    cuaddress in _helperlandContext.ServiceRequestAddresses
                                    on sr.ServiceRequestId equals cuaddress.ServiceRequestId
                                 where sr.Status == Convert.ToInt16(ServiceStatusEnum.completed) && sr.ServiceProviderId == sessionUser.UserID
                                 select new
                                 {
                                     serviceid = sr.ServiceRequestId,
                                     servicestartdate = sr.ServiceStartDate,
                                     customeruser = _helperlandContext.Users.Where(x => x.UserId == sr.UserId).FirstOrDefault(),
                                     serviceaddressstrretname = cuaddress.AddressLine1,
                                     serviceaddresshousenumber = cuaddress.AddressLine2,
                                     servicereqestcity = cuaddress.City,
                                     servicereqestpostalcode = cuaddress.PostalCode,
                                     payment = sr.TotalCost,
                                     servicehoures = sr.ServiceHours
                                 }).Distinct();
            return Json(servicedisapy);

        }
        #endregion Servicehistory

        #region BlockCustomer
        public IActionResult BlockCustomer()
        {
            return View();
        }

        public JsonResult getallcustomer()
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }

            var serviceRequests = (from sr in _helperlandContext.ServiceRequests
                                   join
                                   usr in _helperlandContext.Users
                                   on
                                   sr.UserId equals usr.UserId
                                   where sr.ServiceProviderId == sessionUser.UserID && sr.Status == (int)ServiceStatusEnum.completed
                                   select new
                                   {
                                       serviceproviderid = sr.ServiceProviderId,
                                       customername = usr.FirstName,
                                       customername2 = usr.LastName,
                                       customerprofile = usr.UserProfilePicture,
                                       customeruserid = usr.UserId,
                                       blockeduser = _helperlandContext.FavoriteAndBlockeds.Where(x => x.TargetUserId == usr.UserId).FirstOrDefault()
                                   }).Distinct();
            return Json(serviceRequests);

        }
        public JsonResult BlockCustomerByserviceprovider(int targetedid)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }

            FavoriteAndBlocked fandb = new FavoriteAndBlocked()
            {
                UserId = sessionUser.UserID,
                TargetUserId = targetedid,
                IsFavorite = false,
                IsBlocked = true,
            };

            return Json(_serviceProviderRepository.BlockCutomer(fandb));

        }
        public JsonResult UnBlockCustomerByserviceprovider(int targetedid)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }


            return Json(_serviceProviderRepository.UnBlockCutomer(targetedid));

        }
        #endregion BlockCustomer

        #region ratings
        public IActionResult Ratings()
        {
            return View();
        }

        public JsonResult getservicereated(int ratings)
        {
            var user = HttpContext.Session.GetString("User");
            SessionUser sessionUser = new SessionUser();

            if (user != null)
            {
                sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
            }
           
            var customerratings = _serviceProviderRepository.GetAllservicereated(sessionUser.UserID, ratings);
            return Json(customerratings);
        }
        #endregion ratings
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
    }
}
