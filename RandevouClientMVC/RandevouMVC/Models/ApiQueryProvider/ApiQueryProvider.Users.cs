using Microsoft.AspNetCore.Http;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.ApiQueryProvider
{
    public partial class ApiQueryProvider
    {
        public void CreateUser(UserComplexDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.CreateUserWithLogin(dto);
        }


        public UsersDto GetUser(int userId)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = usersQuery.GetUser(userId, _apiKey);
            return result;
        }

        public UserDetailsDto GetUserDetails(int userId)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = usersQuery.GetUserDetails(userId, _apiKey);
            return result;
        }

        public UsersDto GetMyProfileUser()
            => GetUser(_userId);
        public UserDetailsDto GetMyProfileUserDetails()
             => GetUserDetails(_userId);

        public void UpdateMyProfileUser(UserDetailsDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.UpdateUserDetails(_userId, dto, _apiKey);
        }

        public void UpdateMyProfileUserBasic(UsersDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.UpdateUser(dto, _apiKey);
        }

        public IEnumerable<UsersDto> GetManyUsers(int[] ids)
        {
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = queryUsers.GetManyUsers(_apiKey, ids);
            return result;
        }

        public IEnumerable<int> FindUsers(SearchQueryDto dto)
        {
            var queryFinder = queryProvider.GetQueryProvider<IUserFinderQuery>();
            var result = queryFinder.FindUsers(dto, _apiKey);
            return result;
        }

        public void SetAvatar(Stream fStream, string contentType)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.SetAvatar(_userId, fStream, contentType, _apiKey);
        }

    }
}
