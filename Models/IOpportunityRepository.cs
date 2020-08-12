using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models
{
    public interface IOpportunitiesRepository
    {
        Opportunity addOpp(Opportunity opportunity);
        Opportunity editOpp(Opportunity oppEdit);
        Opportunity deleteOpp(int oppID);
        IEnumerable<Opportunity> oppSearch(string key);
        IEnumerable<Opportunity> centerFilter(string center);

        Opportunity getOpportunity(int oppID);


    }
}
