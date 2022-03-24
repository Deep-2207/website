using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface ICustomerRepository
    {
        List<ServiceRequest> GetAllServicebyUserid(int userid);

        //List<ServiceRequest> get
        User GetUSerbyloginid(int userid);
        
        ServiceRequest GetserviceReqestDetials(int srid);
        List<ServiceRequest> GetAllserviceBySPID(int? spid);
        List<ServiceRequestAddress> GetServicerequestAddress(int srid);
        List<ServiceRequestExtra> GetExtraservicesByServiceid(int srid);
        Rating AddRatings(Rating rating);

        User UpdateUserDetils(User user);
        User Getserviceprovider(int? spid);

        List<ServiceRequest> GetServiceHistoryBySpID(int spid);

       List<Rating> GetRatingsBySpid(int? spid, int? status);
        Rating GetRatingForServicerequest(int srid);

        //useraddress
        List<UserAddress> GetAllAddress(int userid);
        List<UserAddress> GetAllAddressbypostalcode(int userid, string postalcode);
        public UserAddress AddUserAddress(UserAddress userAddress);
        public UserAddress SelectAddressByID(int id);
        public UserAddress UpdateAddress(UserAddress userAddress);
        public UserAddress DeleteAddress(int id);

    }
}
