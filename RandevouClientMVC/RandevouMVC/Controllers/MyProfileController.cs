using Microsoft.AspNetCore.Mvc;
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
        public MyProfileController(IMyProfileManager manager)
        {
            _manager = manager;
        }
        public ViewResult Index()
        {
            var vm = _manager.GetMyProfileVM();
            return View(vm);
        }

        public IActionResult Update(MyProfileViewModel vm)
        {
            _manager.SetProfileData(vm);
            return RedirectToAction("Index");
        }
    }
}
