using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsNews.UI.Models.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name error..!!")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="Password error..!!")]
        public string Password { get; set; }
    }
}