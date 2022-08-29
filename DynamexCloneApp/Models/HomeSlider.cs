using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DynamexCloneApp.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(56)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Subtitle is required")]
        [MaxLength(256)]
        public string Subtitle { get; set; }
        
        // [Required]
        public string ImageUrl { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }
        
    }
}