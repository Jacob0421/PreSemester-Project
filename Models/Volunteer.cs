using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models
{
    public class Volunteer
    {
        [HiddenInput]
        public int id { get; set; }
        [Required]
       public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string CenterPreferences { get; set; }

        //public string Skills { get; set; }

        //public string Availablity { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name="Zip Code")]
        public int ZipCode { get; set; }

        //public string HomePhone { get; set; }

        //public string CellPhone { get; set; }

        //public string WorkPhone { get; set; }

        //public string Email { get; set; } //Shoud we add a regular expression for validation purposes?

        //public string EducationalBackground { get; set; }

        //public string CurrentLicenses { get; set; }

        //public string EmergencyContactName { get; set; }

        //public string EmergencyContactHomePhone { get; set; }

        //public string EmergencyContactWorkPhone { get; set; }

        //public string EmergencyContactEmail { get; set; }

        //public string EmergencyContactAddress { get; set; }

        //public string DriversLicense { get; set; }

        //public string SocialSecurity { get; set; }
        [Required]
        public string ApprovalStatus { get; set; }
    }
}
