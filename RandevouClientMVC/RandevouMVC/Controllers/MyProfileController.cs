using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.MyProfile;
using RandevouMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class MyProfileController : PrimaryController
    {
        readonly IMyProfileManager _manager;
        readonly IDictionaryItemsManager _dictManager;
        public MyProfileController(IMyProfileManager manager, IDictionaryItemsManager dictManager)
        {
            _manager = manager;
            _dictManager = dictManager;
        }
        public ViewResult Index()
        {
            var vm = _manager.GetMyProfileVM();

            if (vm.UserDto.BirthDate.HasValue)
                vm.BirthDate = vm.UserDto.BirthDate.Value;

            vm.AllHairColors = _dictManager.GetAllHairsColors().Select(x => new SelectListItem
            {
                Text = x.DisplayName,
                Value = x.Id.ToString(),
                Selected = x.Id == vm.UserDetails.HairColor
            }).ToList();

            vm.AllEyesColors = _dictManager.GetAllEyesColors().Select(x => new SelectListItem
             {
                 Text = x.DisplayName,
                 Value = x.Id.ToString(),
                 Selected = x.Id == vm.UserDetails.EyesColor
             }).ToList();




            //interests...
            vm.AllInterests = _dictManager.GetAllInterests();
 

            return View(vm);
        }

        public IActionResult Update(MyProfileViewModel vm)
        {
            vm.UserDto.Gender = vm.Gender == Gender.Male ? 'm' : 'f';
            vm.UserDto.BirthDate = vm.BirthDate;

            _manager.SetProfileData(vm);
            return RedirectToAction("Index");
        }
    }
}
