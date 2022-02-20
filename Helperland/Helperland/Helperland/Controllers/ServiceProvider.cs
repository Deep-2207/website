using Helperland.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [CookiesHelper]
    public class ServiceProvider : Controller
    {
        public IActionResult ServiceProviderView()
        {
            return View();
        }
        
    }
}
