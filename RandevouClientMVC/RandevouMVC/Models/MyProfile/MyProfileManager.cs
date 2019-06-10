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

            var vm = new MyProfileViewModel
            {
                UserDetails = detailsDto,
                UserDto = dto,
            };


            if (dto.BirthDate.HasValue)
                vm.BirthDate = dto.BirthDate.Value;

            return vm;
        }

        public void SetProfileData(MyProfileViewModel vm)
        {
            vm.UserDto.Gender = vm.Gender == Gender.Male ? 'm' : 'f';
            vm.UserDto.BirthDate = vm.BirthDate;
            vm.UserDetails.Interests = vm.InterestsDictionary
                .Where(x => x.Selected)
                .Select(x => x.Id).ToArray();

            _queryProvider.UpdateMyProfileUser(vm.UserDetails);
            _queryProvider.UpdateMyProfileUserBasic(vm.UserDto);
        }
    }
}
