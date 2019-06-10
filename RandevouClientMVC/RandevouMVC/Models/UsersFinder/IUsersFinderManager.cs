using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels;
using System.Collections.Generic;

namespace RandevouMVC.Models.UsersFinder
{
    public interface IUsersFinderManager
    {
        IEnumerable<UsersDto> FindUsers(UserFinderQueryViewModel vm);
    }
}