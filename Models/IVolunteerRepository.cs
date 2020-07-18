using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models
{
    public interface IVolunteerRepository
    {
        Volunteer Add(Volunteer volunteer);

        Volunteer Update(Volunteer volunteerChanges);

        Volunteer Delete(Volunteer volunteerDelete);
    }

}
