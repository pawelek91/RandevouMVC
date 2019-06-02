using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouApiCommunication.Messages;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouApiCommunication.UsersFinder;

namespace RandevouMVC.Models.ApiQueryProvider
{
    public class ApiQueryProviderMock : IApiQueryProvider
    {
        public void AcceptFriendshipInvitation(int userSenderId)
        {
            return;
        }

        public void CreateUser(UserComplexDto dto)
        {
            return;
        }

        public IEnumerable<int> FindUsers(SearchQueryDto dto)
        {
            return new []{ 1, 2, 3 };
        }

        public DictionaryItemDto[] GetAllEyesColors()
        {
            return new DictionaryItemDto[]
            {
                new DictionaryItemDto { DisplayName = "jasne", Id = 1},
                new DictionaryItemDto { DisplayName = "ciemne", Id = 2},
            };
        }

        public DictionaryItemDto[] GetAllHairColors()
        {
            return new DictionaryItemDto[]
            {
                new DictionaryItemDto { DisplayName = "jasne", Id = 1},
                new DictionaryItemDto { DisplayName = "ciemne", Id = 2},
            };
        }

        public DictionaryItemDto[] GetAllInterests()
        {
            return new DictionaryItemDto[]
           {
                new DictionaryItemDto { DisplayName = "football", Id = 1},
                new DictionaryItemDto { DisplayName = "basketball", Id = 2},
           };
        }

        public IEnumerable<MessageDto> GetConversation(int speakerId, DateTime? from, DateTime? to)
        {
            return new[]
            {
                new MessageDto
                {
                     Content = "hellohellohellohellohellohellohellohellohellohello",
                      IsRead = false,
                       MessageId = 1,
                        ReceiverId = 1,
                         ReceiverName = "test",
                          SendDate = DateTime.Now,
                           SenderId = 1,
                            SenderName = "testowy",
                },
                new MessageDto
                {
                     Content = "hellohellohellohellohellohellohellohellohellohello",
                      IsRead = false,
                       MessageId = 1,
                        ReceiverId = 1,
                         ReceiverName = "test",
                          SendDate = DateTime.Now,
                           SenderId = 1,
                            SenderName = "testowy",
                },
                new MessageDto
                {
                     Content = "hellohellohellohellohellohellohellohellohellohello",
                      IsRead = false,
                       MessageId = 1,
                        ReceiverId = 1,
                         ReceiverName = "test",
                          SendDate = DateTime.Now,
                           SenderId = 1,
                            SenderName = "testowy",
                }
            };
        }

        public IEnumerable<UsersDto> GetFriends()
        {
            return new[] { GetUser(1), GetUser(1), GetUser(1), GetUser(1) };
        }

        public int GetIdentity(string apiKey)
        {
            return 1;
        }

        public IEnumerable<UsersDto> GetInvitatios()
        {
            return new[] { GetUser(1), GetUser(1) };
        }

        public IEnumerable<LastMessagesDto> GetLastMessages()
        {
            return new[]
            {
                new LastMessagesDto
                {
                     IsRead = false,
                       MessageDate = DateTime.Now,
                        SpeakerId = 1,
                        SpeakerName ="testowy",
                         MessageShortContent="hello!",
                },
                new LastMessagesDto
                {
                     IsRead = false,
                       MessageDate = DateTime.Now,
                        SpeakerId = 1,
                        SpeakerName ="testowy",
                         MessageShortContent="hello!",
                },
                new LastMessagesDto
                {
                     IsRead = false,
                       MessageDate = DateTime.Now,
                        SpeakerId = 1,
                        SpeakerName ="testowy",
                         MessageShortContent="hello!",
                },
            };
        }

        public IEnumerable<UsersDto> GetManyUsers(int[] ids)
        {
            return new[] { GetUser(1), GetUser(1), GetUser(1), GetUser(1), GetUser(1) };
        }

        public UsersDto GetMyProfileUser()
        {
            return new UsersDto
            {
                Id = 1,
                Gender = 'M',
                DisplayName = "testowy",
                Name = "testowy",
                BirthDate = DateTime.Now.AddDays(-1),
            };
        }

        public UsersDto GetUser(int userId)
        {
            return new UsersDto
            {
                BirthDate = DateTime.Now.AddDays(-1),
                DisplayName = "some test user",
                Name = "test",
                Id = 1,
                Gender = 'f',
            };
        }

        public UserDetailsDto GetUserDetails(int userId)
        {
            return new UserDetailsDto
            {
                City = "warsaw",
                EyesColor = 1,
                HairColor = 1,
                Heigth = 180,
                Interests = new[] { 1, 2, 3 },
                Region = "mazowieckie",
                Tattos = 1,
                UserId = 1,
                Width = 190,
            };
        }

        public string Login(string username, string password)
        {
            return "a";
        }

        public void RejectFriendshipInvitation(int userSenderId)
        {
            return;
        }

        public void RemoveFriend(int friendId)
        {
            return;
        }

        public void SendFriendshipInvitation(int toUserId)
        {
            return;
        }

        public void SendMessage(int receiverId, string content)
        {
            return;
        }

        public void SetUserData(string apiKey, int userId)
        {
            return;
        }

        public void UpdateMyProfileUser(UserDetailsDto dto)
        {
            return;
        }

        public void UpdateMyProfileUserBasic(UsersDto dto)
        {
            return;
        }
    }
}
