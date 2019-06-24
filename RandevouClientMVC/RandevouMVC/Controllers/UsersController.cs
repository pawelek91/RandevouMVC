using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class UsersController : BusinessController
    {
        private readonly IUserManager manager;

        public UsersController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = LoggedUserName;
            var vm = manager.GetUserDisplayInfo(id);
            if (vm.User.DisplayName.Equals(LoggedUserName, StringComparison.CurrentCultureIgnoreCase))
                return RedirectToAction("Index", "MyProfile");
            return View(vm);
        }
    }
}
