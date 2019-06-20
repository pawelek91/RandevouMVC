using Microsoft.Extensions.DependencyInjection;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.Models.Authentication;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.Friends;
using RandevouMVC.Models.Messages;
using RandevouMVC.Models.MyProfile;
using RandevouMVC.Models.Users;
using RandevouMVC.Models.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC
{
    public static class BusinessServices
    {
        public static void Register(IServiceCollection services)
        {
            //services.AddSingleton<IApiQueryProvider, ApiQueryProviderMock>();
            services.AddSingleton<IApiQueryProvider, ApiQueryProvider>();

            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IMyProfileManager, MyProfileManager>();
            services.AddSingleton<IDictionaryItemsManager, DictionaryItemsManager>();
            services.AddSingleton<IUsersFinderManager, UsersFinderManager>();
            services.AddSingleton<IUserManager, UsersManager>();
            services.AddSingleton<IMessagesManager, MessagesManager>();
            services.AddSingleton<IFriendsManager, FriendsManager>();
        }
    }
}
