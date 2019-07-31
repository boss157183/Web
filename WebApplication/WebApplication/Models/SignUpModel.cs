using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SignUpModel
    {
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Invalid Username")]
        public string UserName { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Give us your first name.")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Give us your last name.")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Invalid EmailAddress")]
        public string EmailAddress { get; set; }
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "EmailAddress don't match!!")]
        public string ConfirmEmail { get; set; }
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Invalid Password!!")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don't match!!")]
        public string ConfirmPassword { get; set; }
        public int Phone { get; set; }
        public string SignUpError { get; set; }
    }
}