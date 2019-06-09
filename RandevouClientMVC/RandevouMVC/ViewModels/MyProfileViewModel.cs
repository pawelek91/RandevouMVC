using RandevouApiCommunication.Users;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class MyProfileViewModel
    {
        public UsersDto UserDto { get; set; }
        public UserDetailsDto UserDetails { get; set; }
    }
}
