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
                new Volunteer {id = 1, FirstName = "Bob", LastName = "Evans", Username = "BEvans", Password= "1991", StreetAddress = "1995 StreetName Ave", State = "FL", City = "Jacksonville", ZipCode = 32225, ApprovalStatus = "Approved"},
                new Volunteer {id = 2, FirstName = "Jim", LastName = "Evans", Username = "JEvans", Password= "1992", StreetAddress = "1995 StreetName Ave", State = "FL", City = "Jacksonville", ZipCode = 32225, ApprovalStatus = "Pending Approval"}
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
                toBeUpdated.StreetAddress = volunteerChanges.StreetAddress;
                toBeUpdated.City = volunteerChanges.City;
                toBeUpdated.State = volunteerChanges.State;
                toBeUpdated.ZipCode = volunteerChanges.ZipCode;
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
