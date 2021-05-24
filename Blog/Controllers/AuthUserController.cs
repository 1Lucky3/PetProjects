using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class AuthUserController : Controller
    {
        public AuthUserController()
        {

        }
        public IActionResult MainPage()
        {
            ViewBag.Message= Request.Cookies["name"];
            return View();
        }
    }
}
