using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Messages;
using RandevouMVC.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class MessagesController : BusinessController
    {
        private readonly IMessagesManager _manager;

        public MessagesController(IMessagesManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var vm = _manager.GetAllConversations();
            return View(vm);
        }

   
        [HttpGet]
        public ViewResult Details(int id)
        {
            ViewBag.SpeakerId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult Conversation(int id)
        {
            var vm = _manager.GetConversation(id);
            return PartialView(vm);
        }


        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel vm)
        {
            _manager.SendMessage(vm.SpeakerId, vm.Content);
            return RedirectToAction("Details", new { id = vm.SpeakerId });
        }


    }
}
