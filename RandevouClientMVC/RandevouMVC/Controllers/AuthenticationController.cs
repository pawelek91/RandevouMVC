using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandevouMVC.Models.Authentication;
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
        public ActionResult Index()
        {
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
                vm.LoginResult = "Nie udało się zalogować";
                return RedirectToAction("Index");
            }

            else
            {
                HttpContext.Session.SetString("ApiKey", apiKey);
                vm.LoggedUser = _authManager.GetLoggedUser(_ApiKey)?.Name;

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