using Helperland.Core;
using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            var sr = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == null && x.ServiceRequestId == servicerequestid).FirstOrDefault();
            return sr;
        }

        public List<ServiceRequest> GetAllNewServicerequest(bool haspet, int spid)
        {
            List<ServiceRequest> servicedisapy = (List<ServiceRequest>)(from sr in _helperlandContext.ServiceRequests
                                                       join
                                                       usr in _helperlandContext.Users
                                                       on sr.ZipCode equals usr.ZipCode
                                                       join
                                                       cuaddress in _helperlandContext.ServiceRequestAddresses
                                                       on sr.ServiceRequestId equals cuaddress.ServiceRequestId
                                                       join fb in _helperlandContext.FavoriteAndBlockeds on (int?)sr.UserId equals (int?)fb.TargetUserId into fb1
                                                       from fb in fb1.DefaultIfEmpty()
                                                       where usr.UserId == spid && sr.Status == Convert.ToInt16(ServiceStatusEnum.New) && sr.ServiceProviderId == null && sr.HasPets == haspet && (int?)fb.TargetUserId != (int?)sr.UserId
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
                                                           workingwithpet = haspet,
                                                           servicehoures = sr.ServiceHours,
                                                           recordVersion = sr.RecordVersion
                                                       }).Distinct();
            return servicedisapy;
        }

        public List<Rating> GetAllservicereated(int srid, int raings)
        {
            return _helperlandContext.Ratings.Where(x => x.RatingTo == srid && x.Ratings > (raings == 5 ? 0 : raings) && x.Ratings <= (raings == 5 ? 5 : (raings + 1))).Include(x => x.RatingFromNavigation).Include(x => x.ServiceRequest).ToList();
        }

        public int GetCountOfservicerequest(int srid, int status)
        {
            return _helperlandContext.ServiceRequests.Where(sr => sr.ServiceRequestId == srid && status == (int)ServiceStatusEnum.New).Count();
        }

        public User GetHashPetAtHome(int userid)
        {

            return (_helperlandContext.Users.Where(x => x.UserId == userid).FirstOrDefault());
        }

        public string GetMailforTheuserid(int userid)
        {
            var email= _helperlandContext.Users.Where(x => x.UserId == userid).Select(x => x.Email).FirstOrDefault();
            return email;
           
        }

        public List<User> GetUserByZipcode(string zipcode)
        {
           return _helperlandContext.Users.Where(x => x.ZipCode == zipcode).ToList();
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

        public ServiceRequest Updateservicerequest(ServiceRequest serviceRequest)
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
