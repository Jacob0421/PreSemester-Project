<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreSemester_Project.Models;

namespace PreSemester_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Add_Volunteer()
        {
            return View("Add_Volunteer");
        }

        public IActionResult Login()
        {
            return View("Add_Volunteer");
        }

        [HttpPost] //Need to fix this method
        public IActionResult AddVolunteer(Volunteer obj, string Add, string Cancel)
        {
            if (!string.IsNullOrEmpty(Add))
            {
                ViewBag.Message = "Your volunteer was added successfully!";
                return View("Index", obj);   //Need to change the view
            }
            if (!string.IsNullOrEmpty(Cancel))
            {
                ViewBag.Message = "You volunteer was not added.";
                return View("Index", obj);   //Need to change the view
            }
            return View("index", "error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 
=======
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreSemester_Project.Models;

namespace PreSemester_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Add_Volunteer()
        {
            return View("Add_Volunteer");
        }

        public IActionResult Login()
        {
            return View("Add_Volunteer");
        }

        [HttpPost] //Need to fix this method
        public IActionResult AddVolunteer(Volunteer obj, string Add, string Cancel)
        {
            if (!string.IsNullOrEmpty(Add))
            {
                ViewBag.Message = "Your volunteer was added successfully!";
                return View("Index", obj);   //Need to change the view
            }
            if (!string.IsNullOrEmpty(Cancel))
            {
                ViewBag.Message = "You volunteer was not added.";
                return View("Index", obj);   //Need to change the view
            }
            return View("index", "error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 
>>>>>>> b79d4d7746a14669b0ed6cf4b19aa9c7ed5e5a04
