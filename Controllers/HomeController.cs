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
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        private readonly IOpportunitiesRepository _opportunityRepository;

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
            return RedirectToAction("Options");

            /// taking in login form from index.cshtml and gathering variables
            //string username = (Form["UserName"].ToString());
            //string password = (Form["Password"].ToString());

            ////validation of "admin" credentials
            //if (username == "Admin" && password == "Admin")
            //{
            //    //initializing session variables
            //    HttpContext.Session.SetString("Username", username);
            //    HttpContext.Session.SetString("Password", password);
            //    return View("Options");
            //}
            //else
            //{

            //    //message returned if invalid credentials are entered
            //    ViewBag.error = "Username: Admin<br />Password: Admin";
            //    return View("Index");
            //}
        }

        public ActionResult Options()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Volunteers()
        {
            return RedirectToAction("ManageVolunteers");
        }

        [HttpPost]
        public IActionResult Opportunities()
        {
            return View("Index");

        }

        [HttpPost]
        public IActionResult CancelVolunteer()
        {
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();
            ViewData.Model = volList;
            return View("ManageVolunteers");
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

        [HttpPost]
        public RedirectToActionResult CreateOpportunity(Opportunity newOpp)
        {
            _opportunityRepository.addOpp(newOpp);
            return RedirectToAction("ManageOpportunities");
        }

        public RedirectToActionResult DeleteOpportunity(int oppID)
        {
            _opportunityRepository.deleteOpp(oppID);
            return RedirectToAction("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Volunteer toBeChanged = _volunteerRepository.GetVolunteer(id);
            ViewData.Model = toBeChanged;

            return View();
        }

        [HttpGet]
        public ActionResult EditOpportunity(int oppID)
        {
            Opportunity toBeChanged = _opportunityRepository.GetOpportunity(oppID);
            ViewData.Model = toBeChanged;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Edit(Volunteer changedVol)
        {
            _volunteerRepository.Edit(changedVol);

            return RedirectToAction("ManageVolunteers");
        }

        [HttpPost]
        public RedirectToActionResult EditOpportunity(Opportunity changedOpp)
        {
            _opportunityRepository.editOpp(changedOpp);
            return RedirectToAction("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }

        public RedirectToActionResult Delete(int id)
        {
            _volunteerRepository.Delete(id);

            return RedirectToAction("ManageVolunteers");
        }

        [HttpGet]
        public ActionResult Search(string key)
        { 

            IEnumerable<Volunteer> results = _volunteerRepository.Search(key);

            if (results.Any())
            {
                ViewData.Model = results;

                return View("SearchResults");
            }
            else
            {
                TempData["error"] = "Volunteer not Found: Please recheck your spelling.";
                ViewData.Model = _volunteerRepository.GetAllVolunteers();
                return View("ManageVolunteers");
            }

        }

        [HttpGet]
        public ActionResult SearchOpportunity(string key)
        {

            IEnumerable<Opportunity> results = _opportunityRepository.oppSearch(key);

            if (results.Any())
            {
                ViewData.Model = results;

                return View("SearchOppResults");
            }
            else
            {
                TempData["error"] = "Opportunity not Found: Please recheck your spelling.";
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                return View("ManageOpportunities");
            }

        }

        public ActionResult SearchResults()
        {
            ViewData.Model = TempData["Results"] as IEnumerable<Volunteer>;

            return View();
        }

        public ActionResult SearchOppResults()
        {
            ViewData.Model = TempData["Results"] as IEnumerable<Opportunity>;
            return View();
        }

        [HttpGet]
        public ActionResult Filter(string approvalStatus)
        {
            List<Volunteer> results = new List<Volunteer>();
            if (approvalStatus != "All" && approvalStatus != "Approved/Pending Approval")
            {
                results = _volunteerRepository.FilterApprovalStatus(approvalStatus);
                ViewData.Model = results.AsEnumerable();
                
            }
            else if (approvalStatus == "Approved/Pending Approval")
            {
                results = _volunteerRepository.FilterApprovalStatus("Approved");
                results.AddRange(_volunteerRepository.FilterApprovalStatus("Pending Approval"));

                ViewData.Model = results.AsEnumerable();
                ViewData["error"] = "Here";
            }
            else
            {
                ViewData.Model = _volunteerRepository.GetAllVolunteers();
            }

            TempData["filteredBy"] = "Filtered by " + approvalStatus + ".";

            return View("ManageVolunteers");
        }

        //need to add a filter for Opportunities


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
