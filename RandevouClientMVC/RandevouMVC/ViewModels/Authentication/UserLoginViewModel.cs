using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class UserLoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string ApiKey { get; set; }

        public string LoggedUser { get; set; }

        public string LoginResult { get; set; }

    }
}
