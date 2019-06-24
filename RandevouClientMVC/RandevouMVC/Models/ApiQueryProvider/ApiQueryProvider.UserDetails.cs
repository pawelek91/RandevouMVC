using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.ApiQueryProvider
{
    public partial class ApiQueryProvider
    {
        public DictionaryItemDto[] GetAllEyesColors()
        {
            var udQuery = queryProvider.GetQueryProvider<IUsersDictionaryValuesQuery>();
            var result = udQuery.GetEyesColors(_apiKey);
            return result;
        }

        public DictionaryItemDto[] GetAllHairColors()
        {
            var udQuery = queryProvider.GetQueryProvider<IUsersDictionaryValuesQuery>();
            var result = udQuery.GetHairColors(_apiKey);
            return result;
        }

        public DictionaryItemDto[] GetAllInterests()
        {
            var udQuery = queryProvider.GetQueryProvider<IUsersDictionaryValuesQuery>();
            var result = udQuery.GetInterests(_apiKey);
            return result;
        }
  }
}
