using System;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

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
        private readonly IVolunteerRepository _volunteerRepository;

        public HomeController(ILogger<HomeController> logger, IVolunteerRepository volunteerRepository)
        {
            _logger = logger;
            _volunteerRepository = volunteerRepository;
        }

        //working
        public ViewResult Index()
        {
            return View();
        }

        // working
        [HttpPost]
        public ActionResult Login(IFormCollection Form)
        {
            //adding a couple of items to list on start-up


            return RedirectToAction("Landing");

            // LOGIN FORM VALIDATION IS WORKING...
            // WILL UNCOMMENT TOWARDS END OF PROJECT

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

        // working
        public IActionResult Landing()
        {
            var model = _volunteerRepository.GetAllVolunteers();

            return View(model);
        }

        // working
        public ActionResult Create()
        {
            return View();
        }

        // working
        [HttpPost]
        public RedirectToActionResult Create(Volunteer newVolunteer)
        {
            _volunteerRepository.Add(newVolunteer);
            return RedirectToAction("Landing");
        }

        // working
        [HttpGet]
        public RedirectToActionResult Delete(int id)
        {

            Volunteer vol = _volunteerRepository.GetVolunteer(id);
            Volunteer removed = _volunteerRepository.Remove(vol);

            ViewBag.update = (removed.FirstName + " was deleted from the List of Volunteers.");

            return RedirectToAction("Landing");
        }

        // working
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Volunteer toChange = _volunteerRepository.GetVolunteer(id);
            ViewData.Model = toChange;

            return View();
        }

        // working
        [HttpPost]
        public RedirectToActionResult Edit(Volunteer volChanges)
        {

            _volunteerRepository.Edit(volChanges);

            return RedirectToAction("Landing");
        }

        // currently a WIP
        //public ViewResult Details(int id)
        //{
        //    Volunteer model = _volunteerRepository.GetVolunteer(id);

        //    return View(model);
        //}


        // currently a WIP
        //[HttpPost]
        //public ActionResult Search(string key)
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
