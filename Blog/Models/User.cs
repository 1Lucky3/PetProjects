using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Range(1,20)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(1,20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(1, 20)]
        public string Password { get; set; }
    }
}
