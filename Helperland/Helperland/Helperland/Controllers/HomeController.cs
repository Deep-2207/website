﻿using Helperland.Data;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HelperlandContext _helperlandContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,
                                 IHostingEnvironment hostingEnvironment,
                                 HelperlandContext helperlandContext)
        {
            _logger = logger;
            this._helperlandContext = helperlandContext;
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.page = "home";
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
     
        public IActionResult Prices()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string filename = null;
                if (model.attachment != null)
                {
                    string UploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload\\contact-us-attachment");
                    filename = Guid.NewGuid().ToString() + "_" + model.attachment.FileName;
                    string filepath = Path.Combine(UploadsFolder, filename);
                    //model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        model.attachment.CopyTo(fileStream);
                    }

                }
                ContactU Newcontact = new ContactU()
                {
                    Name = model.firstname +" "+ model.lastname,
                    Email = model.email,
                    Subject = model.subject,
                    PhoneNumber = model.mobileno,
                    Message = model.message,
                    UploadFileName = filename
                };
                _helperlandContext.Add(Newcontact);
                _helperlandContext.SaveChanges();
                return RedirectToAction();

            }
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
