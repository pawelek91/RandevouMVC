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
        public UserCreateViewModel Dto { get; set; }

        [Display(Name="Płeć")]
        public Gender Gender { get; set; }
    }

    public class UserCreateViewModel : UserComplexDto
    {
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public new string Password { get; set; }
    }

    
}
