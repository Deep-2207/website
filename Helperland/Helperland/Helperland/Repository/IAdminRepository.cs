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
    }
}
