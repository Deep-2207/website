using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IServiceRequestAddressRepository
    {
        ServiceRequestAddress Add(ServiceRequestAddress serviceRequestAddress);
    }
}
