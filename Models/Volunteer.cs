using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PreSemester_Project.Models
{
    public class Volunteer
    {
        [HiddenInput]
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
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
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name="Zip Code")]
        [MaxLength(5, ErrorMessage = "Zipcode cannot exceed 5 digits")]
        public int ZipCode { get; set; }

        //[Display(Name = "Home Phone")]
        //[MaxLength(12, ErrorMessage = "Phone numbers cannot exceed 12 characters.")]
        //public string HomePhone { get; set; }

        //[Display(Name = "Cell Phone")]
        //[MaxLength(12, ErrorMessage = "Phone numbers cannot exceed 12 characters.")]
        //public string CellPhone { get; set; }

        //[Display(Name = "Work Phone")]
        //[MaxLength(12, ErrorMessage = "Phone numbers cannot exceed 12 characters.")]
        //public string WorkPhone { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        //public string Email { get; set; } //Shoud we add a regular expression for validation purposes?

        //[Display(Name = "Educational Background")]
        //public string EducationalBackground { get; set; }

        //[Display(Name = "Current Licenses")]
        //public string CurrentLicenses { get; set; }

        //[Display(Name = "Emergency Contact Name")]
        //public string EmergencyContactName { get; set; }

        //[Display(Name = "Emergency Contact Home Phone")]
        //[MaxLength(12, ErrorMessage = "Phone numbers cannot exceed 12 characters.")]
        //public string EmergencyContactHomePhone { get; set; }

        //[Display(Name = "Emergency Contact Work Phone")]
        //[MaxLength(12, ErrorMessage = "Phone numbers cannot exceed 12 characters.")]
        //public string EmergencyContactWorkPhone { get; set; }

        //[Display(Name = "Emergency Contact Email")]
        //[RegularExpression(@"^[a-zA-Z0-9.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        //public string EmergencyContactEmail { get; set; }

        //[Display(Name = "Emergency Contact Address")]
        //public string EmergencyContactAddress { get; set; }

        //[Display(Name = "Drivers License")]
        //public string DriversLicense { get; set; }

        //[Display(Name = "Social Security")]
        //[MaxLength(11, ErrorMessage = "Social security numbers cannot exceed 11 characters.")]
        //public string SocialSecurity { get; set; }
        [Required]
        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; }
        
           /* public enum Status
            {
                Approved = 1,
               [Display(Name = "Pending Approval")]
                PendingApproval = 2,
                Disproved = 3,
                Inactive = 4,
                All = 5
            }
        
       */
       
    }
}
