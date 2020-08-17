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
                new Opportunity{oppID = 0, oppName = "Removing Anti-Homeless Architecture", oppCenter = "Alpha", OppDate = new DateTime(2020, 07, 04) },
                new Opportunity{oppID = 1, oppName = "Tutoring Kids in Advanced Calculus", oppCenter = "Charlie", OppDate = new DateTime(2020, 07, 15) },
                new Opportunity{oppID = 2, oppName = "Fighting Against Towing Companies", oppCenter = "Bravo", OppDate = new DateTime(2020, 08, 08) },
                new Opportunity{oppID = 3, oppName = "Run Errands for the Elderly", oppCenter = "Delta", OppDate = new DateTime(2020, 08, 11) }
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
            IEnumerable<Opportunity> searchResults = oppList.Where(s => s.oppName.Contains(key));
            return searchResults;
        }
        public List<Opportunity> CenterFilter(string center)
        {
            List<Opportunity> centerResults = oppList.OrderBy(s => s.oppCenter == center).ToList();
            return centerResults;
        }
        public List<Opportunity> DateFilter(DateTime date)
        {
            List<Opportunity> dateResults = oppList.OrderByDescending(s => s.OppDate == date).ToList();
            return dateResults;
        }
        public Opportunity GetOpportunity(int oppID)
        {
            return oppList.FirstOrDefault(s => s.oppID == oppID);
        }
        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return oppList;
        }

    }
}
