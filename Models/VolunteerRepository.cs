using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private List<Volunteer> _volunteerList;

        public VolunteerRepository()
        {
            _volunteerList = new List<Volunteer>()
            {
                new Volunteer {id = 1, FirstName = "Bob", LastName = "Evans", Username = "BEvans", Password= "1991", Skills= "Knows ASL and Spanish.", Availablity= "Weekends only", StreetAddress = "1995 StreetName Avenue", State = "FL", City = "Jacksonville", ZipCode = 32225, HomePhone = "904-987-6543", CellPhone = "904-789-4561", WorkPhone = "953-963-8521", Email = "Bob.Evans@gmail.com", EducationalBackground = "B.A. Education", CurrentLicenses = "Florida Professional Certificate", EmergencyContactName = "Jill Evans", EmergencyContactHomePhone = "N/A", EmergencyContactWorkPhone = "904-641-3677", EmergencyContactEmail = "Jill.Evans@gmail.com", EmergencyContactAddress = "11401 Old Saint Augustine Rd Jacksonville, FL 32258", DriversLicense = "D123–456-78–910–9", SocialSecurity = "943-01-3274", ApprovalStatus = "Approved"},
                new Volunteer {id = 2, FirstName = "Jim", LastName = "Evans", Username = "JEvans", Password= "1992", Skills= "Has experience working with children.", Availablity= "Friday 8am - 5pm", StreetAddress = "1995 StreetName Avenue", State = "FL", City = "Jacksonville", ZipCode = 32225, HomePhone = "904-654-3210", CellPhone = "904-456-1230", WorkPhone = "875-520-1478", Email = "Jim.Evans@gmail.com", EducationalBackground = "B.A. Social Services", CurrentLicenses = "None", EmergencyContactName = "Becca Evans", EmergencyContactHomePhone = "904-325-9874", EmergencyContactWorkPhone = "698-723-0145", EmergencyContactEmail = "Becca.Evans@gmail.com", EmergencyContactAddress = "5775 Brush Hollow Rd Jacksonville, FL 32258", DriversLicense = "D123–456-77–910–1", SocialSecurity = "842-68-4147", ApprovalStatus = "Pending Approval"},
                new Volunteer {id = 3, FirstName = "James", LastName = "Johnson", Username = "JJohnson", Password= "1993", Skills= "Problem-solving",  Availablity= "Monday and Wednesday after 1pm", StreetAddress = "1993 Tree Avenue", State = "FL", City = "Jacksonville", ZipCode = 32259, HomePhone = "904-321-0987", CellPhone = "904-123-0789", WorkPhone = "326-965-8741", Email = "James.Johnson@gmail.com", EducationalBackground = "Some college (junior)", CurrentLicenses = "None", EmergencyContactName = "Joelle Johnson", EmergencyContactHomePhone = "N/A", EmergencyContactWorkPhone = "545-374-2013", EmergencyContactEmail = "Joelle.Johnson@gmail.com", EmergencyContactAddress = "99 Clay Hill Rd Hartland, VT 05048", DriversLicense = "D223–456-78–510–9", SocialSecurity = "803-76-1247", ApprovalStatus = "Inactive"},
                new Volunteer {id = 4, FirstName = "Ashley", LastName = "Blake", Username = "ABlake", Password= "1994", Skills= "Creativity", Availablity= "Wednesday after 3pm", StreetAddress = "1344 Brannon Avenue", State = "FL", City = "Jacksonville", ZipCode = 32217, HomePhone = "904-123-4567", CellPhone = "904-147-2583", WorkPhone = "323-478-9512", Email = "Ashley.Blake@gmail.com", EducationalBackground = "B.S. Civil Engineering", CurrentLicenses = "Civil Professional Engineer", EmergencyContactName = "Jon Flicker", EmergencyContactHomePhone = "904-974-5862", EmergencyContactWorkPhone = "904-966-5521", EmergencyContactEmail = "Jon.Flicker@gmail.com", EmergencyContactAddress = "14459 Falling Waters Drive Jacksonville, FL 32258", DriversLicense = "D369–497-78–920–2", SocialSecurity = "104-87-6398", ApprovalStatus = "Disapproved"},
                new Volunteer {id = 5, FirstName = "Berry", LastName = "Martin", Username = "BMartin", Password= "1995", Skills= "Leadership and teamwork", Availablity= "Weekdends only", StreetAddress = "544 Alpha Avenue", State = "FL", City = "Jacksonville", ZipCode = 32207, HomePhone = "904-456-7890", CellPhone = "904-258-3690", WorkPhone = "N/A", Email = "Barry.Martin@gmail.com", EducationalBackground = "B.A. Communications", CurrentLicenses = "None", EmergencyContactName = "Linda Martin", EmergencyContactHomePhone = "N/A", EmergencyContactWorkPhone = "314-654-2020", EmergencyContactEmail = "Linda.Martin@gmail.com", EmergencyContactAddress = "1204 N Wells Street Edna, TX 77957", DriversLicense = "D951–476-78–810–4", SocialSecurity = "323-35-8147", ApprovalStatus = "Pending Approval"},
                new Volunteer {id = 6, FirstName = "Diane", LastName = "Porter", Username = "DPorter", Password= "1996", Skills= "Public relations", Availablity= "Monday before 3 pm", StreetAddress = "4630 Cherry Tree Drive", State = "FL", City = "Jacksonville", ZipCode = 32216, HomePhone = "904-951-6234", CellPhone = "904-369-2581", WorkPhone = "N/A", Email = "Diane.Porter@gmail.com", EducationalBackground = "Some college (sophomore)", CurrentLicenses = "None", EmergencyContactName = "Everest Hall", EmergencyContactHomePhone = "904-573-1597", EmergencyContactWorkPhone = "904-302-6210", EmergencyContactEmail = "Everest.Hall@gmail.com", EmergencyContactAddress = "6213 Eclipse Circle Jacksonville, FL 32258", DriversLicense = "D643–456-78–660–0", SocialSecurity = "147-89-6423", ApprovalStatus = "Inactive"},
                new Volunteer {id = 6, FirstName = "Billy", LastName = "Stowe", Username = "BStowe", Password= "1997", Skills= "Time management and planning", Availablity= "Tuesday and Thursday 8am - 6pm", StreetAddress = "340 Brannon Avenue", State = "FL", City = "Jacksonville", ZipCode = 32217, HomePhone = "904-951-8473", CellPhone = "904-258-1472", WorkPhone = "N/A", Email = "Billy.Stowe@gmail.com", EducationalBackground = "High school diploma", CurrentLicenses = "None", EmergencyContactName = "Jen Stowe", EmergencyContactHomePhone = "N/A", EmergencyContactWorkPhone = "855-910-3479", EmergencyContactEmail = "Jen.Stowe@gmail.com", EmergencyContactAddress = "5332 7th Avenue La Grange, IL 60525", DriversLicense = "D197–556-78–910–5", SocialSecurity = "853-64-2013", ApprovalStatus = "Approved"}
            };
        }

    public Volunteer Add(Volunteer volunteer)
        {
            volunteer.id = _volunteerList.Max(v => v.id) + 1;
            _volunteerList.Add(volunteer);
            return volunteer;
        }

        public Volunteer Edit(Volunteer volunteerChanges)
        {
            Volunteer toBeUpdated = _volunteerList.FirstOrDefault(v => v.id == volunteerChanges.id);

            if(toBeUpdated!= null)
            {
                toBeUpdated.FirstName = volunteerChanges.FirstName;
                toBeUpdated.LastName= volunteerChanges.LastName;
                toBeUpdated.Username= volunteerChanges.Username;
                toBeUpdated.Password = volunteerChanges.Password;
                toBeUpdated.CenterPreferences = volunteerChanges.CenterPreferences;
                toBeUpdated.Skills = volunteerChanges.Skills;
                toBeUpdated.Availablity = volunteerChanges.Availablity;
                toBeUpdated.StreetAddress = volunteerChanges.StreetAddress;
                toBeUpdated.City = volunteerChanges.City;
                toBeUpdated.State = volunteerChanges.State;
                toBeUpdated.ZipCode = volunteerChanges.ZipCode;
                toBeUpdated.HomePhone = volunteerChanges.HomePhone;
                toBeUpdated.CellPhone = volunteerChanges.CellPhone;
                toBeUpdated.WorkPhone = volunteerChanges.WorkPhone;
                toBeUpdated.Email = volunteerChanges.Email;
                toBeUpdated.EducationalBackground = volunteerChanges.EducationalBackground;
                toBeUpdated.CurrentLicenses = volunteerChanges.CurrentLicenses;
                toBeUpdated.EmergencyContactName = volunteerChanges.EmergencyContactName;
                toBeUpdated.EmergencyContactHomePhone = volunteerChanges.EmergencyContactHomePhone;
                toBeUpdated.EmergencyContactWorkPhone = volunteerChanges.EmergencyContactWorkPhone;
                toBeUpdated.EmergencyContactEmail = volunteerChanges.EmergencyContactEmail;
                toBeUpdated.EmergencyContactAddress = volunteerChanges.EmergencyContactAddress;
                toBeUpdated.DriversLicense = volunteerChanges.DriversLicense;
                toBeUpdated.SocialSecurity = volunteerChanges.SocialSecurity;
                toBeUpdated.ApprovalStatus = volunteerChanges.ApprovalStatus;
            }

            return toBeUpdated;
        }

        public Volunteer GetVolunteer(int id)
        {
            return _volunteerList.FirstOrDefault(v => v.id == id);
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return _volunteerList;
        }

        public Volunteer Delete(int id)
        {
            var toBeRemoved = _volunteerList.FirstOrDefault(e => e.id == id);
            if(toBeRemoved != null)
            {
                _volunteerList.Remove(toBeRemoved);
            }
            return toBeRemoved;
        }

        public IEnumerable<Volunteer> Search(string key)
        {
            IEnumerable<Volunteer> searchResults = _volunteerList.Where(v => v.FirstName.Contains(key)

                                                                        || v.LastName.Contains(key) 
                                                                        || v.Username.Contains(key)
                                                                        || (v.FirstName + " " + v.LastName).Contains(key));

            return searchResults;
        }
        
        public List<Volunteer> FilterApprovalStatus(string approvalStatus)
        {

            List<Volunteer> results = _volunteerList.Where(v => v.ApprovalStatus == approvalStatus).ToList();

            return results;
        }

    }
}
