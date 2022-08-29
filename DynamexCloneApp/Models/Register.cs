using System;
using System.ComponentModel.DataAnnotations;

namespace DynamexCloneApp.Models
{
    public class Register
    {
        // [Required, MaxLength(35)]
        public string FirstName { get; set; }
        
        [Required, MaxLength(35)]
        public string LastName { get; set; }
        
        [Required, MinLength(7), MaxLength(35), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required, StringLength(10), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public bool IsResident { get; set; }
        
        [Required, MinLength(10), MaxLength(11)]
        public string IdNumber { get; set; }
        
        [Required, StringLength(7)]
        public string IdPin { get; set; }
        
        [Required, MaxLength(255)]
        public string City { get; set; }
        
        [Required, MaxLength(255)]
        public string DynamexBranch { get; set; }
        
        [Required, MaxLength(255)]
        public string HomeAddress { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string CheckPassword { get; set; }
        
        [Required]
        public bool Agreement { get; set; }
    }
}