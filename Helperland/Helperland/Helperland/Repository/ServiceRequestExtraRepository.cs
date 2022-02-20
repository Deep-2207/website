using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class ServiceRequestExtraRepository : IServiceRequestExtraRepository
    {
        private readonly HelperlandContext helperlandContext;

        public ServiceRequestExtraRepository(HelperlandContext _helperlandContext)
        {
            this.helperlandContext = _helperlandContext;
        }
        public ServiceRequestExtra Add(ServiceRequestExtra serviceRequestExtra)
        {
            helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
            helperlandContext.SaveChanges();
            return serviceRequestExtra;    
        }

        
    }
}
