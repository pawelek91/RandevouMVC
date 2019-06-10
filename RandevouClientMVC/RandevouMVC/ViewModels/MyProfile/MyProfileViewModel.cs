using Microsoft.AspNetCore.Mvc.Rendering;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouMVC.ViewModels.Common;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class MyProfileViewModel
    {
        public UsersDto UserDto { get; set; }
        public UserDetailsDto UserDetails { get; set; }

        public InterestViewModel[] InterestsDictionary { get; set; }

        public List<SelectListItem> HairColorsDictionary { get; set; }
        public List<SelectListItem> EyesColorsDictionary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [AllowedDateRange]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
