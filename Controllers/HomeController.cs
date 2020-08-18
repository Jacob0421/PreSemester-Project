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

        public HomeController(ILogger<HomeController> logger, IVolunteerRepository volunteerRepository, IOpportunitiesRepository opportunitiesRepository)
        {
            _opportunityRepository = opportunitiesRepository;
            _logger = logger;
            _volunteerRepository = volunteerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection Form)
        {
            //LOGIN FORM VALIDATION IS WORKING...
            // WILL UNCOMMENT TOWARDS END OF PROJECT
            //return RedirectToAction("Options");

            /// taking in login form from index.cshtml and gathering variables
            string username = (Form["UserName"].ToString());
            string password = (Form["Password"].ToString());

            //validation of "admin" credentials
            if (username == "Admin" && password == "Admin")
            {
                //initializing session variables
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Password", password);
                return View("Options");
            }
            else
            {

                foreach (var volunteer in _volunteerRepository.GetAllVolunteers())
                {
                    if (volunteer.Username == username && volunteer.Password == password)
                    {
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Password", password);
                        return RedirectToAction("VolunteerOptions");
                    }
                }

                ViewBag.error = "Username: Admin<br />Password: Admin";
                return View("Index");
            }
        }

        public ActionResult Options()
        {
            return View();
        }
        ///************************************************************************************************************///
        ///*********************************************Volunteer Methods**********************************************///
        ///************************************************************************************************************///

        [HttpPost]
        public RedirectToActionResult Volunteers()
        {
            return RedirectToAction("ManageVolunteers");
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
        public RedirectToActionResult Create(Volunteer newVol, string submit)
        {

            switch (submit)
            {
                case "Create":
                    _volunteerRepository.Add(newVol);
                    break;
                case "Cancel":
                    break;
            }

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
        public RedirectToActionResult Edit(Volunteer changedVol, string submit)
        {
            switch (submit)
            {
                case "Save":
                    _volunteerRepository.Edit(changedVol);
                    break;
                case "Cancel":
                    break;
            }


            return RedirectToAction("ManageVolunteers");
        }

        [HttpGet]
        public ActionResult Search(string key)
        {

            if (!string.IsNullOrEmpty(key))
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
            else
            {
                TempData["error"] = "Empty String: Please try again.";
                ViewData.Model = _volunteerRepository.GetAllVolunteers();
                return View("ManageVolunteers");
            }

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
        public ActionResult OpportunityMatches(int id)
        {
            Volunteer findVolOpp = _volunteerRepository.GetVolunteer(id);
            List<Opportunity> results = new List<Opportunity>();
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();

            foreach (Opportunity opp in oppList)
            {
                if (opp.oppCenter == findVolOpp.CenterPreferences)
                {
                    results.Add(opp);

                }
            }

            if (results.Count == 0 && HttpContext.Session.GetString("Username") == "Admin")
            {
                ViewData["error"] = "Opportunity match not found.";
                return RedirectToAction("ManageVolunteers");
            }
            else if (results.Count == 0)
            {
                ViewData["error"] = "No matches found.";
                ViewData.Model = new OpportunityMatchesView { _volunteer = findVolOpp, _opportunityList = results };
                return View("VolunteerOptions");
            }
            else
            {

                var finalResults = new OpportunityMatchesView { _volunteer = findVolOpp, _opportunityList = results };

                if (HttpContext.Session.GetString("Username") != "Admin")
                    return View("MyOpportunityMatches", finalResults);


                return View(finalResults);
            }
        }

        ///************************************************************************************************************///
        ///*********************************************End Volunteer Methods******************************************///
        ///************************************************************************************************************///

        /// ***********************************************************************************************************///
        /// ********************************************Beginning of non-admin Methods*********************************///
        /// ***********************************************************************************************************///
        public IActionResult VolunteerOptions()
        {
            Volunteer volIn = _volunteerRepository.GetVolunteerbyUsername(HttpContext.Session.GetString("Username"));
            ViewData.Model = volIn;
            return View();
        }
        public IActionResult Edited()
        {
            ViewData.Model = _volunteerRepository.GetVolunteer((int)TempData["id"]);
            return View("MyDetails");
        }

        [HttpGet]
        public IActionResult MyDetails(int id)
        {
            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }
        [HttpGet]
        public IActionResult EditMyDetails(int id)
        {

            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }
        [HttpPost]
        public RedirectToActionResult EditMyDetails(Volunteer MyChanges, string submit)
        {
            switch (submit)
            {
                case "Save":
                    _volunteerRepository.Edit(MyChanges);
                    break;
                case "Cancel":
                    break;
            }

            TempData["id"] = MyChanges.id;
            return RedirectToAction("Edited");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Password");
            return View("Index");
        }

        /// ************************************************************************************************************///
        /// ********************************************End of non-admin Methods****************************************///
        /// ************************************************************************************************************///


        ///*************************************************************************************************************///
        ///*********************************************Opportunity Methods*********************************************///
        ///*************************************************************************************************************///

        [HttpPost]
        public RedirectToActionResult Opportunities()
        {
            return RedirectToAction("ManageOpportunities");

        }

        public ActionResult ManageOpportunities()
        {
            ViewData.Model = _opportunityRepository.GetAllOpportunities();
            return View("ManageOpportunities");
        }

        public IActionResult CreateOpportunity()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult CreateOpportunity(Opportunity newOpp, string submit)
        {
            switch (submit)
            {
                case "Save":
                    _opportunityRepository.addOpp(newOpp);
                    break;
                case "Cancel":
                    break;
            }
            return RedirectToAction("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult SearchOpportunity(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                IEnumerable<Opportunity> results = _opportunityRepository.oppSearch(key);

                if (results.Any())
                {
                    ViewData.Model = results;

                    return View("SearchOppResults");
                }
                else
                {
                    TempData["error"] = "Opportunity not found.";
                    ViewData.Model = _opportunityRepository.GetAllOpportunities();
                    return View("ManageOpportunities");
                }
            }
            else
            {
                TempData["error"] = "Empty String";
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                return View("ManageOpportunities");
            }

        }

        [HttpGet]
        public ActionResult FilterCenter(string center)
        {
            List<Opportunity> results = new List<Opportunity>();
            if (center == "Jacksonville Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "Miami Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "St. Petersburg Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "All")
            {
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                TempData["filteredBy"] = "You are viewing all of the opportunities posted.";
            }
            else
            {
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                TempData["filteredBy"] = "There are no opportunities that match your filtering criteria.";
            }



            return View("ManageOpportunities");
        }

        public ActionResult FilterPosted()
        {
            List<Opportunity> results = new List<Opportunity>();
            DateTime today = DateTime.Now.Date;
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();
            foreach (Opportunity opp in oppList)
            {
                DateTime posted = opp.datePosted.Date;
                TimeSpan difference = today.Subtract(posted);
                int daysDiff = difference.Days;

                if (daysDiff <= 60)
                {
                    results.Add(opp);
                    ViewData.Model = results.AsEnumerable();

                }
                else
                {

                }
            }
            if (results.Count == 0)
            {
                TempData["MethodResult"] = "There were no opportunitites posted within the past 60 days.";
                return View("ManageOpportunities");
            }
            TempData["MethodResult"] = "You are viewing of the opportunitites posted within the past 60 days.";
            ViewData.Model = results.AsEnumerable();
            return View("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult EditOpportunity(int oppID)
        {
            Opportunity toBeChanged = _opportunityRepository.GetOpportunity(oppID);
            ViewData.Model = toBeChanged;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult EditOpportunity(Opportunity changedOpp, string submit)
        {
            switch (submit)
            {
                case "Save":
                    _opportunityRepository.editOpp(changedOpp);
                    break;
                case "Cancel":
                    break;
            }

            return RedirectToAction("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult oppDetails(int oppID)
        {
            ViewData.Model = _opportunityRepository.GetOpportunity(oppID);
            return View();
        }

        [HttpGet]
        public RedirectToActionResult DeleteOpportunity(int oppID)
        {
            _opportunityRepository.deleteOpp(oppID);
            return RedirectToAction("ManageOpportunities");
        }

        [HttpGet]
        public ActionResult VolunteerMatches(int id)
        {
            Opportunity findopp = _opportunityRepository.GetOpportunity(id);
            List<Volunteer> results = new List<Volunteer>();
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();

            foreach (Volunteer vol in volList)
            {
                if (vol.CenterPreferences == findopp.oppCenter)
                {
                    results.Add(vol);

                }
                else
                {

                }
            }

            if (results.Count == 0)
            {
                TempData["error"] = "Volunteer match not found.";
                return RedirectToAction("ManageOpportunities");
            }
            else
            {

                var finalResults = new VolunteerMatchesView { opportunity = findopp, _volunteerList = results };
                return View(finalResults);
            }
        }
        ///************************************************************************************************************///
        ///*********************************************End Opportunity Methods****************************************///
        ///************************************************************************************************************///


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
