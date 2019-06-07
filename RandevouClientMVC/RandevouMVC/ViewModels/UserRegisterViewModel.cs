using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public class UserRegisterViewModel
    {
        public UserComplexDto Dto { get; set; }

        public Gender Gender { get; set; }
    }

    
}
