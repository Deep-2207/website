using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Helperland.Repository
{
    public class ServiceproviderRepository : IServiceProviderRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public ServiceproviderRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }

        public FavoriteAndBlocked BlockCutomer(FavoriteAndBlocked fandb)
        {
            _helperlandContext.FavoriteAndBlockeds.Add(fandb);
            _helperlandContext.SaveChanges();
            return fandb;
        }

        public ServiceRequest canceled(int serviceid)
        {
            var servicerequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceid).FirstOrDefault();
            return servicerequest;
        }

        public ServiceRequest completed(int serivceid)
        {
            var servicerequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serivceid).FirstOrDefault();
            return servicerequest;
        }




        //public ServiceRequest Acceptsr(int servicereqestid, int spid)
        //{

        //    //ServiceRequest sr = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == null && x.ServiceRequestId == servicereqestid).FirstOrDefault();
        //    //sr.ServiceProviderId = spid;
        //    //sr.SpacceptedDate = DateTime.Now;

        //    //List<ServiceRequest> oldsr = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == spid).ToList();

        //    //foreach (var timecheck in oldsr)
        //    //{
        //    //    DateTime newdatetime = Convert.ToDateTime(timecheck.ServiceStartDate);
        //    //    DateTime newdatetimewithservicehours = newdatetime.AddMinutes(timecheck.ServiceHours * 60);
        //    //    //DateTime newtime = Convert.ToDateTime(chanhgetime);
        //    //    bool serviceRequestConflict = false;


        //    //    if (timecheck.ServiceRequestId != servicereqestid)
        //    //    {
        //    //        if (timecheck.ServiceStartDate <= newdatetimewithservicehours && newdatetime <= timecheck.ServiceStartDate.AddMinutes(timecheck.ServiceHours * 60))
        //    //        {
        //    //            serviceRequestConflict = false;
        //    //            break;
        //    //            return
        //    //        }
        //    //        else
        //    //        {
        //    //            serviceRequestConflict = true;
        //    //        }
        //    //    }
        //    //}

        //    //_helperlandContext.ServiceRequests.Update(sr);
        //    //_helperlandContext.SaveChanges();

        //    return spid;
        //}

        public ServiceRequest Detailsofsr(int servicerequestid)
        {
            var  sr  = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == null && x.ServiceRequestId == servicerequestid).FirstOrDefault();
            return sr;
        }

        public User GetHashPetAtHome(int userid)
        {

            return (_helperlandContext.Users.Where(x => x.UserId == userid).FirstOrDefault());
        }

        public List<ServiceRequest> listoldrequest(int serviceproviderid)
        {
          List<ServiceRequest> listsr = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == serviceproviderid).ToList();
            return listsr;
        }

        public FavoriteAndBlocked UnBlockCutomer(int targetid)
        {
            var unblock = _helperlandContext.FavoriteAndBlockeds.Where(x => x.TargetUserId == targetid).FirstOrDefault();
            _helperlandContext.FavoriteAndBlockeds.Remove(unblock);
            _helperlandContext.SaveChanges();
            return (unblock);
        }

        public ServiceRequest Updateservicereqest(ServiceRequest serviceRequest)
        {
            _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();
            return serviceRequest;
        }


        //public List<ServiceRequest> GetNewServiceReqest(int userid)
        //  {


        //      return sr;
        //  }

    }
}
