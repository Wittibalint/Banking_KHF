using Banking.data.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Web.Shared
{
    public class RegisterModel
    {
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

    }
}
