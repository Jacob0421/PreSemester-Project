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
        List<Opportunity> centerFilter(string center);
        List<Opportunity> dateFilter(DateTime date);
        Opportunity GetOpportunity(int oppID);
        IEnumerable<Opportunity> GetAllOpportunities();

    }
}
