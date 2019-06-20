using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.Friends;
using RandevouMVC.ViewModels.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class FriendsController : PrimaryController
    {
        private readonly IFriendsManager manager;

        public FriendsController(IFriendsManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public IActionResult Index(ControllerActionResult actionResult = null)
        {
            if(actionResult != null)
            {
                ViewBag.ActionResult = actionResult;
            }
            var vm = new FriendsMainViewModel();
            vm.UserFriends = manager.GetUserFriends();
            vm.FriendshipInvitations = manager.GetFriendsInvitations();
            return View(vm);
        }

        

        [HttpGet]
        public IActionResult Accept(int id)
        {
            manager.AcceptFriendshipInvitation(id);
            return RedirectToAction("Index", new ControllerActionResult { Message = "Zaakceptowano zaproszenie" });
        }

        [HttpGet]
        public IActionResult Decline(int id)
        {
            manager.RejectFriendshipInvitation(id);
            return RedirectToAction("Index", new ControllerActionResult { Message = "Odrzucono zaproszenie" });
        }

        public IActionResult RemoveFriend(int id)
        {
            manager.RemoveFriend(id);
            return RedirectToAction("Index", new ControllerActionResult { Message = "Usunięto ze znajomych" });
        }

        public IActionResult Invite(int id)
        {
            manager.SendFriendshipInvitation(id);
            return RedirectToAction("Index", new ControllerActionResult { Message = "Wysłano zaproszenie" });
        }
    }
}
