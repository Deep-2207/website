using Helperland.Data;
using Helperland.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Core
{
    public class CookiesHelper : ActionFilterAttribute
    {
        private HelperlandContext _helperlandContext;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session.GetString("User");

            if(user == null)
            {
                string userCookies = filterContext.HttpContext.Request.Cookies["EmailId"];

                if(userCookies != null)
                {
                    _helperlandContext = filterContext.HttpContext.RequestServices.GetService(typeof(HelperlandContext)) as HelperlandContext;       
                    var _user = _helperlandContext.Users.Where(x => x.Email == userCookies).FirstOrDefault();

                    SessionUser sessionUser = new SessionUser()
                    {
                        UserID = _user.UserId,
                        UserName = _user.FirstName + " " + _user.LastName,
                        UserType = ((UserTypeEnum)_user.UserTypeId).ToString()
                    };
                    filterContext.HttpContext.Session.SetString("User", JsonConvert.SerializeObject(sessionUser));


                    if (_user.UserTypeId == (int)UserTypeEnum.Customer)
                    {
                        filterContext.Result = new RedirectToRouteResult(new { action = "servicehistory", controller = "customer" });
                        return;
                    }

                    else if (_user.UserTypeId == (int)UserTypeEnum.ServiceProvider) {
                        filterContext.Result = new RedirectToRouteResult(new { action = "ServiceProviderView", controller = "serviceprovider" });
                        return;
                    }

                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new { action = "UserManagement", controller = "admin" });
                        return;
                    }
                       
                }
               
                
            }
            //else
        }
    }
}
