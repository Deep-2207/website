﻿using Helperland.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [CookiesHelper]
    public class CustomerController : Controller
    {
        public IActionResult ServiceHistory()
        {
            return View();
        }
        public IActionResult BookService()
        {
            return View();
        }
    }
}
