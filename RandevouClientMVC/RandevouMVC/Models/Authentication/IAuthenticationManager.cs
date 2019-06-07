using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.Authentication
{
    public interface IAuthenticationManager
    {
        //returns api key
        string Login(string username, string password);

        void Register(UserComplexDto dto);

        UsersDto GetLoggedUser(string apiKey);
    }
}
