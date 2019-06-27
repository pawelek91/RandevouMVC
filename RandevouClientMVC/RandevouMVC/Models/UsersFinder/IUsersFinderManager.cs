using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.UsersFinder;
using System.Collections.Generic;

namespace RandevouMVC.Models.UsersFinder
{
    public interface IUsersFinderManager
    {
        IEnumerable<UsersFinderResultViewModel> FindUsers(UserFinderQueryViewModel vm);
    }
}