using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebPortal.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "First Name", Prompt = "Enter Your First Name")]
        [RegularExpression(@"^[a-zA-Z]{4,50}$",ErrorMessage ="Only alphabet are allowed and less than 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name", Prompt = "Enter Your Last Name")]
        [RegularExpression(@"^[a-zA-Z]{4,50}$", ErrorMessage = "Only alphabet are allowed and less than 50 characters")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(25, ErrorMessage = "Username should not be more than 25 characters")]
        [Display(Name = "User Name", Prompt = "Enter Your User Name")]
        public string UserName { get; set; }
        [Required]
        public string Location { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [Display(Name = "Mobile Number", Prompt = "10 Digit Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Phone Number is not valid.")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password", Prompt = "Enter 6 Digit Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$", ErrorMessage = "should have atleast 1 special char, 1 numeric char, 1 capital letter,1 small letter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Not Matched")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password", Prompt = "Same With Above Password")]
        public string ConfirmPassword { get; set; }
    }
    public class Locations
    {
        public static List<SelectListItem> Cities { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Bangalore", Text = "Bangalore" },
        new SelectListItem { Value = "Hyderabad", Text = "Hyderabad" },
        new SelectListItem { Value = "Kochi", Text = "Kochi"  },
    };
    }

    public class Genders
    {
        public static List<SelectListItem> Types { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Male", Text = "Male" },
        new SelectListItem { Value = "Female", Text = "Female" },
    };
    }
}
