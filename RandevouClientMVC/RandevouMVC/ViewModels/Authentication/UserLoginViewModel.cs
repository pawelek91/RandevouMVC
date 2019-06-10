using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name="Login")]
        public string Login { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ApiKey { get; set; }

        public string LoggedUser { get; set; }

        public string LoginResult { get; set; }

    }
}
