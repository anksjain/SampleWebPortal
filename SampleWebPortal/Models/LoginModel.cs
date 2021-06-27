using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebPortal.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User Name", Prompt = "Enter Your User Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password", Prompt = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
