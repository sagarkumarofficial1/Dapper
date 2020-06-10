using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace DotNetMVC.Data.Modal
{
    public class UserMaster
    {

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [EmailAddress(ErrorMessage = "Plase type valid Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Remote("IsEmailExist", "Validation", ErrorMessage = "Email Address Already exist. Please Try Diffrent.", AdditionalFields = "InitialEmail")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
