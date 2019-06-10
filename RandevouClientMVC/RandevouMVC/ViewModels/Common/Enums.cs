using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels
{
    public enum Gender
    {
        [Display(Name="Mężczyzna")]
        Male,
        [Display(Name = "Kobieta")]
        Female
    }

    public enum Tatoos
    {
        [Display(Name="-")]
        Null,
        [Display(Name="Brak")]
        Not,
        [Display(Name="Tak")]
        Has,
    }
}
