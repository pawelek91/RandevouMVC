using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class UserRegisterViewModel
    {
        public UserComplexViewModel Dto { get; set; }

        public Gender Gender { get; set; }
    }

    public class UserComplexViewModel : UserComplexDto
    {
        [DataType(DataType.Password)]
        public new string Password { get; set; }
    }

    
}
