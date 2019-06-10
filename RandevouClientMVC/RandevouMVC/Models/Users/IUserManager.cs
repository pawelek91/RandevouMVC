using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.Users;

namespace RandevouMVC.Models.Users
{
    public interface IUserManager
    {
        UserComplexViewModel GetUserDisplayInfo(int userId);
    };
}
