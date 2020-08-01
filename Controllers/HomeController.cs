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

        private readonly IVolunteerRepository _volunteerRepository;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVolunteerRepository volunteerRepository)
        {
            _logger = logger;
            _volunteerRepository = volunteerRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Login(IFormCollection Form)
        {
            // LOGIN FORM VALIDATION IS WORKING...
            // WILL UNCOMMENT TOWARDS END OF PROJECT
            return RedirectToAction("ManageVolunteers");

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

        public ActionResult ManageVolunteers()
        {
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();

            ViewData.Model = volList;
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Volunteer newVol)
        {
            _volunteerRepository.Add(newVol);


            return RedirectToAction("ManageVolunteers");
        }

        public RedirectToActionResult Delete(int id)
        {
            _volunteerRepository.Delete(id);

            return RedirectToAction("ManageVolunteers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Volunteer toBeChanged = _volunteerRepository.GetVolunteer(id);
            ViewData.Model = toBeChanged;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Edit(Volunteer changedVol)
        {
            _volunteerRepository.Edit(changedVol);

            return RedirectToAction("ManageVolunteers");
        }

        //Search is Currently a WIP
        [HttpGet]
        public ActionResult Search(string key)
        {

            IEnumerable<Volunteer> results = _volunteerRepository.Search(key);

            ViewData.Model = results;
            return View("SearchResults");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 
