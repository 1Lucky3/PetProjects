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

namespace Blog.Controllers
{
    public class UserController: Controller
    {
        private readonly UsersDbContext _db;
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
                    return RedirectToAction("UserProfile", "AuthUser", checkUserInfo);
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
