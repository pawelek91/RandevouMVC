using RandevouMVC.Models.Common;
using RandevouMVC.Models.Friends;
using RandevouMVC.ViewModels.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Users
{
    public class UserComplexViewModel
    {
        public FriendshipStatus FriendshipStatus { get; set; }
        public UserBasicViewModel User { get; set; }
        public UserDetailsViewModel Details { get; set; }

        public UserComplexViewModel()
        {
            Details = new UserDetailsViewModel();
        }
     }
}
