using RandevouApiCommunication.Users.DictionaryValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.Common
{
    public interface IDictionaryItemsManager
    {
        DictionaryItemDto[] GetAllHairsColors();
        DictionaryItemDto[] GetAllEyesColors();
        DictionaryItemDto[] GetAllInterests();

        DictionaryItemDto EmptyElement { get; }
    }
}
