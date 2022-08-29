using System;
using Microsoft.AspNetCore.Identity;

namespace DynamexCloneApp.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsResident { get; set; }
        public string IdNumber { get; set; }
        public string IdPin { get; set; }
        public string City { get; set; }
        public string DynamexBranch { get; set; }
        public string HomeAddress { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public bool Agreement { get; set; }
    }
}