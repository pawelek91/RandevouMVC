using Microsoft.Extensions.DependencyInjection;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.Models.Authentication;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.MyProfile;
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
            services.AddSingleton<IApiQueryProvider, ApiQueryProviderMock>();
            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IMyProfileManager, MyProfileManager>();
            services.AddSingleton<IDictionaryItemsManager, DictionaryItemsManager>();
        }
    }
}
