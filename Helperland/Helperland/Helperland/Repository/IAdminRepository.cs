using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Helperland.Repository
{
    public interface IAdminRepository
    {
        //public List<ServiceRequest> allservicerequest();
        public List<User> allnewuser();
        ServiceRequestAddress GetServicerequestAddress(int srid);
        ServiceRequestAddress UpdateServicerequestAddress(ServiceRequestAddress serviceRequestAddress);
        ServiceRequest Updateservicerequest(ServiceRequest serviceRequest);
        List<User> GetAllUserList();
        List<User> GetAllUserBySearch(string srterm);
        List<User> GetAllCustomerBySearch(string srterm);
        List<User> GetAllServiceproviderBySearch(string srterm);
        List<User> GetUserByTypeId(int typeid);
        List<User> GetAllServiceprovider();
        List<User> GetAllServiceproviderbyZipcode(string zipcode);
    }
}
