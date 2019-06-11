using RandevouMVC.ViewModels.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Users
{
    public class UserComplexViewModel
    {
        public UserBasicViewModel User { get; set; }
        public UserDetailsViewModel Details { get; set; }

        public UserComplexViewModel()
        {
            Details = new UserDetailsViewModel();
        }

     }
}
