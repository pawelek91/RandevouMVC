using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.Friends
{
    public interface IFriendsManager
    {
        IEnumerable<UsersDto> GetUserFriends();
        IEnumerable<UsersDto> GetFriendsInvitations();
        void SendFriendshipInvitation(int userId);
        void AcceptFriendshipInvitation(int userId);
        void RejectFriendshipInvitation(int userId);
        void RemoveFriend(int friendId);



    }
}
