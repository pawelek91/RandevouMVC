using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouApiCommunication.Users;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.Models.Common;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.Users;

namespace RandevouMVC.Models.Users
{
    public class UsersManager : BusinessManager, IUserManager
    {
        private readonly IDictionaryItemsManager dictManager;

        public UsersManager(IApiQueryProvider apiQueryProvider, IDictionaryItemsManager dictManager) : base(apiQueryProvider)
        {
            this.dictManager = dictManager;
        }

        public UserComplexViewModel GetUserDisplayInfo(int userId)
        {
            var vm = new UserComplexViewModel();
            vm.User = new ViewModels.UsersFinder.UserBasicViewModel(_queryProvider.GetUser(userId));

            var ud = _queryProvider.GetUserDetails(userId);
            vm.Details.Width = ud.Width;
            vm.Details.Weight = ud.Heigth;
            vm.Details.Tatoos = ud.Tattos.HasValue ? ud.Tattos > 0  : false;

            if (ud.EyesColor.HasValue)
                vm.Details.EyesColor = dictManager.GetAllEyesColors().FirstOrDefault(x => x.Id == ud.EyesColor)?.DisplayName;

            if (ud.HairColor.HasValue)
                vm.Details.HairColor = dictManager.GetAllHairsColors().FirstOrDefault(x => x.Id == ud.HairColor)?.DisplayName;

            if(ud.Interests.Any())
            {
                vm.Details.Interests = dictManager.GetAllInterests()
                                .Where(x => ud.Interests.Any(y => y == x.Id))
                                .Select(x => x.DisplayName).ToArray();
            }
            else
            {
                vm.Details.Interests = new string[0];
            }

            return vm;
        }

  
    }
}
