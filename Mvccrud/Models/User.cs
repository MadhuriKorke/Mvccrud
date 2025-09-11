using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvccrud.Models
{
    public class User
    {
        //[Required(ErrorMessage = "Email is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]

        [Required(ErrorMessage = "Name is required.")]
        public string UName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string UAddress { get; set; }

        public int ID { get; set; }

        public string Gender { get; set; }
        public int SelectedCountry { get; set; }

        public List<User> Users { get; set; }

        //public List<User> lstuser { get; set; }

        //public List<User> SubjectList { get; set; }
        //public List<User> Options { get; set; }
    }

}