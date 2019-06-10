using Microsoft.AspNetCore.Mvc.Rendering;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
using RandevouMVC.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class UserFinderViewModel
    {
      //  public List<UsersDto> FoundUsers { get; set; }
        public UserFinderQueryViewModel QueryModel { get; set; }

        public UserFinderViewModel()
        {
        //    FoundUsers = new List<UsersDto>();
            QueryModel = new UserFinderQueryViewModel();
        }

    }

    public class UserFinderQueryViewModel
    {
        public SearchQueryDto SearchQuery { get; set; }
        public InterestViewModel[] InterestsDictionary { get; set; }
        public List<SelectListItem> HairColorsDictionary { get; set; }
        public List<SelectListItem> EyesColorsDictionary { get; set; }
        public Gender Gender { get; set; }

        public Tatoos Tatoos { get; set; }

    }
}
