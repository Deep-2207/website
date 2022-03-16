using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Repository;
using Microsoft.AspNetCore.Mvc;
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

        public AdminController(HelperlandContext helperlandContext ,
                                IAdminRepository adminRepository)
        {
            this._helperlandContext = helperlandContext;
            this._adminRepository = adminRepository;
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
                                     }).ToList();
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

    }
}
