using RandevouApiCommunication.Messages;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouApiCommunication.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.ApiQueryProvider
{
    public interface IApiQueryProvider
    {
        void SetUserData(string apiKey, int userId);
        string Login(string username, string password);

        int GetIdentity(string apiKey);

        #region friends
        IEnumerable<UsersDto> GetFriends();
        void RemoveFriend(int friendId);
        IEnumerable<UsersDto> GetInvitatios();
        void SendFriendshipInvitation(int toUserId);
        void AcceptFriendshipInvitation(int userSenderId);
        void RejectFriendshipInvitation(int userSenderId);
        #endregion

        #region messsages
        IEnumerable<LastMessagesDto> GetLastMessages();
        IEnumerable<MessageDto> GetConversation(int speakerId, DateTime? from, DateTime? to);
        void SendMessage(int receiverId, string content);
        #endregion

        #region user details
        DictionaryItemDto[] GetAllEyesColors();
        DictionaryItemDto[] GetAllHairColors();
        DictionaryItemDto[] GetAllInterests();
        #endregion

        #region users
        void CreateUser(UserComplexDto dto);
        UsersDto GetUser(int userId);
        UserDetailsDto GetUserDetails(int userId);
        UsersDto GetMyProfileUser();
        void UpdateMyProfileUser(UserDetailsDto dto);
        void UpdateMyProfileUserBasic(UsersDto dto);
        IEnumerable<UsersDto> GetManyUsers(int[] ids);
        IEnumerable<int> FindUsers(SearchQueryDto dto);
        #endregion



    }
}
