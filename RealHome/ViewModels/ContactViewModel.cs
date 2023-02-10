using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealHome.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter your name!")]
        [MaxLength(40, ErrorMessage = "There is not enough space of your name ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your email here")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter an invalid E-mail")]
        [Display(Name = "Email:")]
        [MaxLength(50, ErrorMessage = "There is not enough space of your E-mail ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to write message")]
        [Display(Name = "Message:")]
        [MaxLength(500, ErrorMessage = "Your message is too long, write it few")]
        public string Message { get; set; }
    }
}