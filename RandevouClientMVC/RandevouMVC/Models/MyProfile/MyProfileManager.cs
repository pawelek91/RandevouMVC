using System;
using System.Collections.Generic;
using System.IO;
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

            vm.Gender = null;
            if (dto.Gender.HasValue)
                vm.Gender = dto.Gender == 'f' ? Gender.Female : Gender.Male;
            

            if (dto.BirthDate.HasValue)
                vm.BirthDate = dto.BirthDate.Value;

            if(detailsDto.AvatarImage != null && detailsDto.AvatarImage.Length >0 && !string.IsNullOrWhiteSpace(detailsDto.AvatarContentType))
            {
                string base64String = Convert.ToBase64String(detailsDto.AvatarImage, 0, detailsDto.AvatarImage.Length);
                vm.ImageStr = string.Format("data:{0};base64,{1}", detailsDto.AvatarContentType, base64String);
            }
            return vm;
        }

        public void SetAvatar(MyProfileViewModel vm)
        {
            var stream = new MemoryStream();
            vm.NewAvatar.CopyTo(stream);
            string content = vm.NewAvatar.ContentType;
            _queryProvider.SetAvatar(stream, content);
            stream.Dispose();
        }

        public void SetProfileData(MyProfileViewModel vm)
        {
            if(vm.Gender.HasValue)
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
