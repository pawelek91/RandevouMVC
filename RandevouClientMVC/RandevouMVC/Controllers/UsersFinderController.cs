using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandevouMVC.Models.Common;
using RandevouMVC.Models.UsersFinder;
using RandevouMVC.ViewModels;
using RandevouMVC.ViewModels.Common;
using RandevouMVC.ViewModels.UsersFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class UsersFinderController : BusinessController
    {
        private readonly IUsersFinderManager _manager;
        private readonly IDictionaryItemsManager _dictManager;

        public UsersFinderController(IUsersFinderManager manager, IDictionaryItemsManager dictManager)
        {
            _manager = manager;
            _dictManager = dictManager;
        }
        [HttpGet]
        public ViewResult Index()
        {
            var vm = new UserFinderViewModel();

            var emptyElement = new SelectListItem
            {
                Text = _dictManager.EmptyElement.DisplayName,
                Value = ""
            };

            vm.QueryModel.InterestsDictionary = _dictManager.GetAllInterests()
                            .Select(x =>
                            new InterestViewModel(x)).ToArray();

            vm.QueryModel.HairColorsDictionary = new List<SelectListItem>() { emptyElement };
            vm.QueryModel.HairColorsDictionary.AddRange(_dictManager.GetAllHairsColors().Select(x => new SelectListItem
            {
                Text = x.DisplayName,
                Value = x.Id.ToString(),
            }).ToList());



            vm.QueryModel.EyesColorsDictionary = new List<SelectListItem>() { emptyElement };
            vm.QueryModel.EyesColorsDictionary.AddRange(_dictManager.GetAllEyesColors().Select(x => new SelectListItem
            {
                Text = x.DisplayName,
                Value = x.Id.ToString(),
            }).ToList());

            return View(vm);
        }

        [HttpPost]
        public ViewResult Search(UserFinderViewModel vm)
        {
            var result = _manager.FindUsers(vm.QueryModel);
            var resultVm = result.Select(x => new UserBasicViewModel(x)).ToList();
            return View(resultVm);
        }
    }
}
