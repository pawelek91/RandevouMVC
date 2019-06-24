using RandevouApiCommunication.Users;
using RandevouMVC.ViewModels.UsersFinder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Users
{
    public class UserDetailsViewModel
    {
        [Display(Name = "Włosy")]
        public string HairColor { get; set; }

        [Display(Name = "Oczy")]
        public string EyesColor { get; set; }

        [Display(Name = "Zainteresowania")]
        public string[] Interests { get; set; }

        [Display(Name = "Tatuaże")]
        public bool Tatoos { get; set; }

        [Display(Name = "Wzrost")]
        public int? Width { get; set; }

        [Display(Name = "Waga")]
        public int? Weight { get; set; }

        public string ImageStr { get; set; }
    }
}
