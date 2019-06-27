using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.UsersFinder
{
    public class UsersFinderResultViewModel
    {
        public UserComplexViewModel UserBasicDto { get; set; }
        
        public string AvatarContentType { get; set; }
        public byte[] AvatarContentBytes { get; set; }

        public string ImageStr
        {
            get
            {
                if (AvatarContentBytes.Length == 0 || string.IsNullOrEmpty(AvatarContentType))
                    return string.Empty;

                string base64String = Convert.ToBase64String(AvatarContentBytes, 0, AvatarContentBytes.Length);
                return  string.Format("data:{0};base64,{1}", AvatarContentType, base64String);
            }
        }
    }
}
