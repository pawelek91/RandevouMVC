using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouApiCommunication.Users;
using RandevouMVC.Models.ApiQueryProvider;

namespace RandevouMVC.Models.Authentication
{
    public class AuthenticationManager : BusinessManager, IAuthenticationManager
    {
        public AuthenticationManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public string Login(string username, string password)
        {
            var result = _queryProvider.Login(username, password);
            return result;
        }

        public void Register(UserComplexDto dto)
        {
            _queryProvider.CreateUser(dto);
        }

        public UsersDto GetLoggedUser(string apiKey)
        {
            var identity = _queryProvider.GetIdentity(apiKey);
            var user = _queryProvider.GetUser(identity);
            return user;
        }

    }
}
