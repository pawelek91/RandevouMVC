using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Authentication;
using RandevouMVC.Models.Common;
using RandevouMVC.ViewModels;

namespace RandevouMVC.Controllers
{
    public class AuthenticationController : PrimaryController
    {
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }

        [HttpGet]
        public ActionResult Index(ControllerActionResult result = null)
        {
            if (result?.Message != null)
                ViewBag.OperationResult = result.Message;

            var vm = new UserLoginViewModel
            {
                Login = string.Empty,
                Password = string.Empty,
                ApiKey = _ApiKey,
            };
            
            if (!string.IsNullOrWhiteSpace(_ApiKey))
            { 
                vm.LoggedUser  = _authManager.GetLoggedUser(_ApiKey)?.Name;
            }

            return View(vm);
        }

     
        [HttpPost]
        public IActionResult Login(UserLoginViewModel vm)
        {
            string apiKey = _authManager.Login(vm.Login, vm.Password);
            if(string.IsNullOrWhiteSpace(apiKey))
            {
                var result = new ControllerActionResult { Message = "Nie udało się zalogować" };
                return RedirectToAction("Index", result);
            }

            else
            {
                HttpContext.Session.SetString("ApiKey", apiKey);
                vm.LoggedUser = _authManager.GetLoggedUser(_ApiKey)?.Name;
                HttpContext.Session.SetString("UserName", vm.LoggedUser);
                return View("Index", vm);
            }
        }


        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Dto.UserDto.Name))
            {
                ModelState.AddModelError("Creating account", "Nazwa użytkownika jest wymagna");
                return View("Register", vm);
            }

            vm.Dto.UserDto.Gender = vm.Gender == Gender.Male ? 'm' : 'f';
            _authManager.Register(vm.Dto);
            return RedirectToAction("Index");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ApiKey");
            return RedirectToAction("Index");
        }


        // POST: Authentication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authentication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

      
    }
}