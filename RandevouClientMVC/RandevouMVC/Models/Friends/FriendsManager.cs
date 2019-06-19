using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouApiCommunication.Users;
using RandevouMVC.Models.ApiQueryProvider;

namespace RandevouMVC.Models.Friends
{
    public class FriendsManager : BusinessManager, IFriendsManager
    {
        public FriendsManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public IEnumerable<UsersDto> GetFriendsInvitations()
        {
            var result = _queryProvider.GetInvitatios();
            return result;
        }

        public IEnumerable<UsersDto> GetUserFriends()
        {
            var result = _queryProvider.GetFriends();
            return result;
        }

        public void SendFriendshipInvitation(int userId)
        {
            _queryProvider.SendFriendshipInvitation(userId);
        }

        public void AcceptFriendshipInvitation(int userId)
        {
            _queryProvider.AcceptFriendshipInvitation(userId);
        }

        public void RejectFriendshipInvitation(int userId)
        {
            _queryProvider.RejectFriendshipInvitation(userId);
        }

        public void RemoveFriend(int friendId)
        {
            _queryProvider.RemoveFriend(friendId);
        }
    }
}
