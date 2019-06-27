using RandevouApiCommunication.Users;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.UsersFinder
{
    public class UsersFinderManager: BusinessManager, IUsersFinderManager
    {
        public UsersFinderManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public IEnumerable<UsersFinderResultViewModel> FindUsers(UserFinderQueryViewModel vm)
        {
            if(vm.Gender!=null)
                vm.SearchQuery.Gender = vm.Gender == Gender.Male ? 'm' : 'f';
            vm.SearchQuery.InterestIds = vm.InterestsDictionary.Where(x => x.Selected).Select(x => x.Id)?.ToArray();

            if (vm.Tatoos != Tatoos.Null)
                vm.SearchQuery.Tatoos = vm.Tatoos == Tatoos.Has ? true : false;

            var ids = _queryProvider.FindUsers(vm.SearchQuery);
            var users = _queryProvider.GetManyUsers(ids.ToArray());

            var avatars = _queryProvider.GetUsersAvatars(ids);

            var result = new List<UsersFinderResultViewModel>();
            foreach(var user in users)
            {
                var avatarInfo = avatars.Where(x => x.UserId == user.Id).FirstOrDefault();
                result.Add(new UsersFinderResultViewModel
                {
                    UserBasicDto = new ViewModels.Users.UserComplexViewModel() { User = new UserBasicViewModel(user) },
                    AvatarContentBytes = avatarInfo?.AvatarContentBytes ?? new byte[0],
                    AvatarContentType = avatarInfo?.AvatarContentType ?? string.Empty,
                });
            }
            return result;
        }
    }
}
