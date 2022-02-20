using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public ServiceRequestRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }
        public ServiceRequest Add(ServiceRequest serviceRequest)
        {
            _helperlandContext.ServiceRequests.Add(serviceRequest);
            _helperlandContext.SaveChanges();
            return serviceRequest;
        }
    }
}
