using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class UsersController : PrimaryController
    {
        private readonly IUserManager manager;

        public UsersController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public ViewResult Details(int userId)
        {
            var vm = manager.GetUserDisplayInfo(userId);
            return View(vm);
        }
    }
}
