﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using PreSemester_Project.Models;
using Microsoft.AspNetCore.Http;

namespace PreSemester_Project.Controllers
{
    public class HomeController : Controller
    {
        
        /*
         * 
         * Tentative process using the site
         * 
         * WILL UPDATE THIS AS WE MOVE ON IN THE PROJECT:
         * 
         * 1.) Index (Login page) -Done
         * 2.) Login() (Login Validation) => Landing -Done
         * 3.) Landing Page => Add_Volunteers => AddVolunteers() OR Landing Page => Search Results Page => Edit Page (Maybe pop-up) => Landing Page
         * 
         * 
         */


        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(IFormCollection Form)
        {
            // LOGIN FORM VALIDATION IS WORKING...
            // WILL UNCOMMENT TOWARDS END OF PROJECT
            return View("Options");

            ///// taking in login form from index.cshtml and gathering variables
            //string username = (Form["UserName"].ToString());
            //string password = (Form["Password"].ToString());

            ////validation of "admin" credentials
            //if (username == "Admin" && password == "Admin")
            //{
            //    //initializing session variables
            //    HttpContext.Session.SetString("Username", username);
            //    HttpContext.Session.SetString("Password", password);
            //    return View("Landing");
            //} 
            //else
            //{

            //    //message returned if invalid credentials are entered
            //    ViewBag.error = "Invalid Credentials: Please re-enter.";
            //    return View("Index");
            //}


            
        }

        public IActionResult Landing()
        {
            return View("Add_Volunteer");
        }

        public IActionResult Add_Volunteer()
        {
            return View("Add_Volunteer");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

          public IActionResult Options()
        {
            return View("Options");
        }


        [HttpPost] //Need to fix this method
        public IActionResult AddVolunteer(Volunteer obj, string Add, string Cancel)
        {
            //if (!string.IsNullOrEmpty(Add))
            //{
            //    ViewBag.Message = "Your volunteer was added successfully!";
            //    return View("Index", obj);   //Need to change the view
            //}
            //if (!string.IsNullOrEmpty(Cancel))
            //{
            //    ViewBag.Message = "You volunteer was not added.";
            //    return View("Index", obj);   //Need to change the view
            //}
            return View("index", "error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 
