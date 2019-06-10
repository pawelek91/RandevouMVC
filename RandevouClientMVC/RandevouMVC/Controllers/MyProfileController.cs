using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.MyProfile;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.Common;
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
         
            var emptyElement = new SelectListItem
            {
                Text = _dictManager.EmptyElement.DisplayName,
                Value = ""
            };


            vm.HairColorsDictionary = _dictManager.GetAllHairsColors().Select(x => new SelectListItem
            {
                Text = x.DisplayName,
                Value = x.Id.ToString(),
                Selected = x.Id == vm.UserDetails.HairColor
            }).ToList();
            vm.HairColorsDictionary.Add(emptyElement);

            vm.EyesColorsDictionary = _dictManager.GetAllEyesColors().Select(x => new SelectListItem
             {
                 Text = x.DisplayName,
                 Value = x.Id.ToString(),
                 Selected = x.Id == vm.UserDetails.EyesColor
             }).ToList();
            vm.EyesColorsDictionary.Add(emptyElement);



            vm.InterestsDictionary = _dictManager.GetAllInterests()
                                .Select(x =>
                                new InterestViewModel(x, vm.UserDetails.Interests.Any(id => id == x.Id))).ToArray();
             

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(MyProfileViewModel vm)
        {
            _manager.SetProfileData(vm);
            return RedirectToAction("Index");
        }
    }
}
