using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.MyProfile
{
    public interface IMyProfileManager
    {
        MyProfileViewModel GetMyProfileVM();
        void SetProfileData(MyProfileViewModel vm);

        void SetAvatar(MyProfileViewModel vm);
    }
}
