using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouMVC.Models.ApiQueryProvider;

namespace RandevouMVC.Models.Common
{
    public class DictionaryItemsManager : BusinessManager, IDictionaryItemsManager
    {
        public DictionaryItemsManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public DictionaryItemDto EmptyElement => new DictionaryItemDto
        {
            DisplayName = "-",
            Name = "None",
            Id = null,
        };

        public DictionaryItemDto[] GetAllEyesColors()
        {
            return _queryProvider.GetAllEyesColors();
        }

        public DictionaryItemDto[] GetAllHairsColors()
        {
            return _queryProvider.GetAllHairColors();
        }

        public DictionaryItemDto[] GetAllInterests()
        {
            return _queryProvider.GetAllInterests();
        }
    }
}
