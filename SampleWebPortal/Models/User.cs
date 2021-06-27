using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebPortal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MyLocation { get; set; }
        public string PhoneNumber {get; set;}
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MyPassword { get; set; }
    }
}
