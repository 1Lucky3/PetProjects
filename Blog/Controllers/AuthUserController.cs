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
        private User _ame;
        public AuthUserController()
        {
        }
        public IActionResult UserProfile(User ame)
        {
            _ame = ame;
            ViewBag.Message = ame;
            return View();
        }
        public IActionResult MainPage()
        {
            
            return View();
        }
    }
}
