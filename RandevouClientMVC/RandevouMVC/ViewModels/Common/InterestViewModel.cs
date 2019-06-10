using RandevouApiCommunication.Users.DictionaryValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Common
{
    public class InterestViewModel
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public bool Selected { get; set; }

        public InterestViewModel(DictionaryItemDto dictionaryItem, bool isSelected=false)
        {
            Id = dictionaryItem.Id.Value;
            DisplayName = dictionaryItem.DisplayName;
            Selected = isSelected;
        }

        public InterestViewModel()
        {

        }
    }
}
