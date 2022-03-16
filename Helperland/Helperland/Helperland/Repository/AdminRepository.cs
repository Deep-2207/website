using Helperland.Data;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Helperland.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public AdminRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }

        public List<User> allnewuser()
        {
            var newuser = _helperlandContext.Users.Select(x => x).ToList();
            return newuser;
        }

        //public List<ServiceRequest> allservicerequest()
        //{
        //    //var allservicerequest = _helperlandContext.ServiceRequests.Include(x => x.User).Include(x => x.ServiceRequestExtras).Include(x => x.ServiceRequestAddresses).Include(x => x.ServiceProvider).ToList();
        //    //var allservicerequest = _helperlandContext.ServiceRequests.Include(x => x.User)
        //    //                            .Include(x => x.ServiceRequestAddresses)
        //    //                            .Include(x => x.ServiceProvider)
        //    //                            .ToList();

        //    //var data = (from sr in helperLandContext.ServiceRequests
        //    //            join uc in helperLandContext.Users on sr.UserId equals uc.UserId
        //    //            join sra in helperLandContext.ServiceRequestAddresses on sr.ServiceRequestId equals sra.ServiceRequestId
        //    //            join usp in helperLandContext.Users on (int?)sr.ServiceProviderId equals (int?)usp.UserId into usp1
        //    //            from usp in usp1.DefaultIfEmpty()
        //    //            join rt in helperLandContext.Ratings on (int?)sr.ServiceRequestId equals (int?)rt.ServiceRequestId into rt1
        //    //            from rt in rt1.DefaultIfEmpty()
        //    //            orderby sr.ServiceRequestId descending
        //    //            select new
        //    //            {
        //    //                ServiceRequestId = sr.ServiceRequestId,
        //    //                ServiceStartDateTime = sr.ServiceStartDate,
        //    //                ServiceDuration = sr.ServiceHours,
        //    //                CustomerName = uc.FirstName + " " + uc.LastName,
        //    //                CustomerAddress = sra.AddressLine1 + " " + sra.AddressLine2 + ", " + sra.PostalCode + " " + sra.City + "-" + sra.State,
        //    //                ServiceProviderId = (int?)sr.ServiceProviderId,
        //    //                ServiceProviderProfile = usp.UserProfilePicture,
        //    //                ServiceProviderName = usp.FirstName + ' ' + usp.LastName,
        //    //                ServiceProviderRate = (decimal?)rt.Ratings,
        //    //                ServiceStatus = sr.Status
        //    //            }).ToList();

        //    return 
        //}
    }
}
