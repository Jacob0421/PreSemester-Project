using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models { 

    public class Volunteer
    {
        public int id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

    }
}


//public string LastName { get; set; }

//public string Username { get; set; }

//public string Password { get; set; }

//public string CenterPreferences { get; set; }

//public string Skills { get; set; }

//public string Availablity { get; set; }

//public string StreetAddress { get; set; }

//public string City { get; set; }

//public string State { get; set; }

//public int ZipCode { get; set; }

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


//public string ApprovalStatus { get; set; }

