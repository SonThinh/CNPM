using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Areas.Staff.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Enter your account")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string PassWord { get; set; }
        public bool Remember { get; set; }
    }
}