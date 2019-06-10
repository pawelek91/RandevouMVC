using RandevouApiCommunication.Users;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.ViewModels;
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

        public IEnumerable<UsersDto> FindUsers(UserFinderQueryViewModel vm)
        {
            vm.SearchQuery.Gender = vm.Gender == Gender.Male ? 'm' : 'f';
            vm.SearchQuery.InterestIds = vm.InterestsDictionary.Where(x => x.Selected).Select(x => x.Id)?.ToArray();

            if (vm.Tatoos != Tatoos.Null)
                vm.SearchQuery.Tatoos = vm.Tatoos == Tatoos.Has ? true : false;

            var ids = _queryProvider.FindUsers(vm.SearchQuery);
            var users = _queryProvider.GetManyUsers(ids.ToArray());
            return users;
        }
    }
}
