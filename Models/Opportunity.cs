using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class Opportunity
    {
        [HiddenInput]
        public int oppID { get; set; }
        [Required]
        [Display (Name = "Opportunity Name")]
        public string oppName { get; set; }
        [Required]
        [Display (Name = "Opportunity Center")]
        public string oppCenter { get; set; }
        [Required]
        [Display (Name = "Date")]
        public DateTime OppDate { get; set; }


    }
}
