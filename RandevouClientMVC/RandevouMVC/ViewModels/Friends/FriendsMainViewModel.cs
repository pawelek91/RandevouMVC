using RandevouApiCommunication.Users;
using RandevouMVC.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Friends
{
    public class FriendsMainViewModel
    {
        public IEnumerable<UsersDto> UserFriends { get; set; }
        public IEnumerable<UsersDto> FriendshipInvitations { get; set; }
    }
}
