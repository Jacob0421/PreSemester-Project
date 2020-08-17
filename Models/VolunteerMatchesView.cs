using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class VolunteerMatchesView
    {
        public List<Volunteer> _volunteerList { get; set; }

        public Opportunity opportunity { get; set; }
    }
}
