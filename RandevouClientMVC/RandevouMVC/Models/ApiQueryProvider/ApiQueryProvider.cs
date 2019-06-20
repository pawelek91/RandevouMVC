using RandevouApiCommunication;
using RandevouApiCommunication.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.ApiQueryProvider
{
    public partial class ApiQueryProvider : IApiQueryProvider
    {
        private static string _apiKey;
        private static int _userId;

        public ApiQueryProvider()
        {
            queryProvider = ApiCommunicationProvider.GetInstance();
        }

        public void SetUserData(string apiKey, int userId)
        {
            _apiKey = apiKey;
            _userId = userId;
        }
        ApiCommunicationProvider queryProvider;


        public string Login(string username, string password)
        {
            string key = null;
            var authQuery = queryProvider.GetQueryProvider<IAuthenticationQuery>();
            try
            {
                key = authQuery.GetLoginAuthKey(username, password);
            }
            catch(RandevouApiCommunication.Exceptions.Unathorized exception)
            {

            }
           
            return key;
        }

        public int GetIdentity(string apiKey)
        {
            var authQuery = queryProvider.GetQueryProvider<IAuthenticationQuery>();
            var id = authQuery.GetIdentity(apiKey);
            return id;
        }
    }
    
}
