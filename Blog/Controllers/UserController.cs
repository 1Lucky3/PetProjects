using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Controllers
{
    public class UserController: Controller
    {
        private readonly UsersDbContext _db;

        public object HttpCookie { get; private set; }

        public UserController(UsersDbContext db)
        {
            _db = db;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("Registration");
            }
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckSignIn(string email, string password)
        {
            try
            {
                var checkUserInfo = _db.User.First(x => x.Email == email);
                if (checkUserInfo.Password == password && checkUserInfo.Email == email)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Append("name", checkUserInfo.Name,options);
                    return RedirectToAction("MainPage", "AuthUser");
                }
                else
                {
                    return View("SignIn");
                }
            }
            catch (Exception)
            {

                return View("SignIn");
            }

        }

    }
}
