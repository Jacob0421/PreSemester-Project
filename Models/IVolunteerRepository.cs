using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models
{
    public interface IVolunteerRepository
    {
        Volunteer Add(Volunteer volunteer);
        Volunteer Edit(Volunteer volunteerChanges);
        Volunteer Delete(int id);
        IEnumerable<Volunteer> GetAllVolunteers();
        IEnumerable<Volunteer> Search(string key);
        Volunteer GetVolunteer(int id);
        List<Volunteer> FilterApprovalStatus(string approvalStatus);
    }

}
