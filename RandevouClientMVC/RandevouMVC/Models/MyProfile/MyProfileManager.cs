using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.ViewModels;

namespace RandevouMVC.Models.MyProfile
{
    public class MyProfileManager : BusinessManager, IMyProfileManager
    {
        public MyProfileManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public MyProfileViewModel GetMyProfileVM()
        {
            var dto = _queryProvider.GetMyProfileUser();
            var detailsDto = _queryProvider.GetUserDetails(dto.Id.Value);

            return new MyProfileViewModel
            {
                UserDetails = detailsDto,
                UserDto = dto,
            };
                
        }

        public void SetProfileData(MyProfileViewModel vm)
        {
            _queryProvider.UpdateMyProfileUser(vm.UserDetails);
            _queryProvider.UpdateMyProfileUserBasic(vm.UserDto);
        }
    }
}
