using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class OpportunityRespository : IOpportunitiesRepository
    {
        private List<Opportunity> oppList;
        public OpportunityRespository()
        {
            oppList = new List<Opportunity>()
            {
                new Opportunity{oppID = 0, oppName = "test", oppCenter = "Test Center"}
            };
        }
        public Opportunity addOpp(Opportunity opportunity)
        {
            opportunity.oppID = oppList.Max(s => s.oppID) + 1;
            oppList.Add(opportunity);
            return opportunity;
        }
        public Opportunity editOpp(Opportunity opportunity)
        {
            Opportunity edited = oppList.FirstOrDefault(s => s.oppID == opportunity.oppID);
            if(edited != null)
            {
                edited.oppName = opportunity.oppName;
                edited.oppCenter = opportunity.oppCenter;
            }
            return opportunity;
        }
        public Opportunity deleteOpp(int opportunity)
        {
            Opportunity toBeDeleted = oppList.FirstOrDefault(s => s.oppID == opportunity);
            if (toBeDeleted != null)
            {
                oppList.Remove(toBeDeleted);
            }
            return toBeDeleted;
        }
        public IEnumerable<Opportunity> oppSearch(string key)
        {
            IEnumerable<Opportunity> seachResults = oppList.Where(s => s.oppName.Contains(key));
            return seachResults;
        }
        public IEnumerable<Opportunity> centerFilter(string key)
        {
            IEnumerable<Opportunity> filterResults = oppList.Where(s => s.oppCenter.Contains(key));
            return filterResults;
        }
        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return oppList;
        }
        public Opportunity getOpportunity(int oppID)
        {
            return oppList.FirstOrDefault(s => s.oppID == oppID);
        }

    }
}
