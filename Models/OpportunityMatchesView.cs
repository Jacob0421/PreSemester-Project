using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class OpportunityMatchesView
    {
        public Volunteer _volunteer { get; set; }

        public List<Opportunity> _opportunityList { get; set; }
    }
}
