using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class MessagesController : PrimaryController
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
        public ViewResult Details(int speakerId)
        {
            var vm = _manager.GetConversation(speakerId);
            return View(vm);
        }
    }
}
