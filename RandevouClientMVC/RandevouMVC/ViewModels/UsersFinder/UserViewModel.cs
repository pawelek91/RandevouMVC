using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.UsersFinder
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(UsersDto userDto)
        {
            Id = userDto.Id.Value;
            DisplayName = userDto.DisplayName;
            Gender = userDto.Gender == 'f' ? Gender.Female : Gender.Male;

            var difference = DateTime.Now - userDto.BirthDate.Value;
            DateTime zeroTime = new DateTime(1, 1, 1);

            Age = (zeroTime + difference).Year - 1;
        }
    }
}
