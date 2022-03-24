using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Helperland.Repository
{
    public interface IServiceProviderRepository
    {
        User GetHashPetAtHome(int userid);
        //  List<ServiceRequest> GetNewServiceReqest(int userid);

       // ServiceRequest Acceptsr(int servicereqestid);

        ServiceRequest Detailsofsr(int servicerequestid);

        List<ServiceRequest> listoldrequest(int serviceproviderid);

        ServiceRequest completed(int serivceid);
       
        ServiceRequest Updateservicereqest(ServiceRequest serviceRequest);

        FavoriteAndBlocked BlockCutomer(FavoriteAndBlocked fandb);
        FavoriteAndBlocked UnBlockCutomer(int targetid);

        List<ServiceRequest> GetAllNewServicerequest(bool haspet, int spid);

        public int GetCountOfservicerequest(int srid, int status);

        ServiceRequest Updateservicerequest(ServiceRequest serviceRequest);
        List<User> GetUserByZipcode(string zipcode);
        List<Rating> GetAllservicereated(int srid,int raings);
        string GetMailforTheuserid(int userid);
    }
}
