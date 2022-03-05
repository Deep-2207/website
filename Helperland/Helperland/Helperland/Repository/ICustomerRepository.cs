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

        Rating AddRatings(Rating rating);

        User UpdateUserDetils(User user);
    }
}
