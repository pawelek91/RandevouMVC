using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public abstract class PrimaryController:Controller
    {
        protected string _ApiKey
            => HttpContext.Session.GetString("ApiKey");
    }
}
