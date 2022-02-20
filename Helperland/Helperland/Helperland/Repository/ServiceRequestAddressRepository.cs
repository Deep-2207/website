using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class ServiceRequestAddressRepository : IServiceRequestAddressRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public ServiceRequestAddressRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }
      
        public ServiceRequestAddress Add(ServiceRequestAddress serviceRequestAddress)
        {
            _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);
            _helperlandContext.SaveChanges();
            return serviceRequestAddress;
        }
    }
}
