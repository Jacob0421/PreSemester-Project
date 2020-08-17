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
            DateTime datePosted1 = new DateTime(2020, 7, 21);
            DateTime datePosted2 = new DateTime(2019, 11, 19);
            DateTime datePosted3 = new DateTime(2020, 2, 6);
            DateTime datePosted4 = new DateTime(2019, 8, 27);
            DateTime datePosted5 = new DateTime(2020, 1, 29);
            DateTime datePosted6 = new DateTime(2020, 3, 17);
            DateTime datePosted7 = new DateTime(2020, 6, 8);
            DateTime datePosted8 = new DateTime(2019, 12, 24);
            DateTime datePosted9 = new DateTime(2020, 7, 15);

            DateTime timeOfEvent1 = new DateTime(2020, 8, 30, 13, 30, 0);
            DateTime timeOfEvent2 = new DateTime(2020, 11, 1, 17, 45, 0);
            DateTime timeOfEvent3 = new DateTime(2020, 9, 28, 8, 0, 0);
            DateTime timeOfEvent4 = new DateTime(2020, 10, 15, 14, 0, 0);
            DateTime timeOfEvent5 = new DateTime(2021, 1, 30, 9, 30, 0);
            DateTime timeOfEvent6 = new DateTime(2020, 11, 6, 9, 0, 0);
            DateTime timeOfEvent7 = new DateTime(2021, 2, 14, 19, 0, 0);
            DateTime timeOfEvent8 = new DateTime(2020, 12, 20, 15, 0, 0);
            DateTime timeOfEvent9 = new DateTime(2021, 3, 9, 8, 0, 0);

            oppList = new List<Opportunity>()
            {
                new Opportunity {oppID = 1, oppName="Food Drive", datePosted = datePosted1, oppCenter = "Jacksonville Location", address = "8523 Normandy Blvd, Jacksonville, FL, 32221", TimeOfEvent = timeOfEvent1, description="Collect non-perishable goods and sort them for further distribution."},
                new Opportunity {oppID = 2, oppName="Christmas Fundraiser", datePosted = datePosted2, oppCenter = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent2, description="Distribute flyers around local neighborhoods."},
                new Opportunity {oppID = 3, oppName="Clothing Drive", datePosted = datePosted3, oppCenter = "St. Petersburg Location", address = "3190 Tyrone Blvd. N., St. Petersburg, FL, 33710", TimeOfEvent = timeOfEvent3, description="Collect and sort clothes that will be distrbuted to children in need."},
                new Opportunity {oppID = 4, oppName="Halloween Party", datePosted = datePosted4, oppCenter = "Jacksonville Location", address = "11830 Old Kings Rd, Jacksonville, Florida 32219, USA", TimeOfEvent = timeOfEvent4, description="Carve, paint and pick pumpikns from a pumpkin patch. This event is open to the public. We are partnered with the farm and will recieve half of all sales made during this event. As a volunteer you will man the painting and carving stations and other assigned duties. "},
                new Opportunity {oppID = 5, oppName="Clothing Drive", datePosted = datePosted5, oppCenter = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent5, description="Collect and sort clothes that will be distrbuted to children in need."},
                new Opportunity {oppID = 6, oppName="Valentines Day Party", datePosted = datePosted6, oppCenter = "St. Petersburg Location", address = "3190 Tyrone Blvd. N., St. Petersburg, FL, 33710", TimeOfEvent = timeOfEvent6, description="Exchange gifts, dance, and complete arts and crafts with kids in a group home."},
                new Opportunity {oppID = 7, oppName="Valentines Day Gala", datePosted = datePosted7, oppCenter = "Jacksonville Location", address = "1000 Water St, Jacksonville, FL 32204", TimeOfEvent = timeOfEvent7, description="This Gala will raise money to buy presents and host events for children in group homes. As a volunteer you will be waiting tables or checking people in as they arrive."},
                new Opportunity {oppID = 8, oppName="Christmas Party", datePosted = datePosted8, oppCenter = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent8, description="Decorate cookies, make ornaments and give presents to kids in a group home."},
                new Opportunity {oppID = 9, oppName="Food Drive", datePosted = datePosted9, oppCenter = "St. Petersburg Location", address = "401 5th St N, St Petersburg, FL", TimeOfEvent = timeOfEvent9, description="Collect non-perishable goods and sort them for further distribution."}

            };
        }
        public Opportunity addOpp(Opportunity opportunity)
        {
            opportunity.datePosted = DateTime.Now;
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
            IEnumerable<Opportunity> searchResults = oppList.Where(s => s.oppName.ToLower().Contains(key.ToLower()) || s.oppCenter.ToLower().Contains(key.ToLower()) || s.description.ToLower().Contains(key.ToLower()));
            return searchResults;
        }
        public List<Opportunity> FilterCenter(string center)
        {

            List<Opportunity> results = oppList.Where(o => o.oppCenter == center).ToList();

            return results;
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
