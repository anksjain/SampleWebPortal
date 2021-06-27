using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebPortal.Models;
using Scrypt;

namespace SampleWebPortal.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var userExist = _context.PortalUser.Where(x => x.UserName.ToLower().Equals(user.Username.ToLower())).FirstOrDefault();
                if (userExist != null)
                {
                    ScryptEncoder encrypt = new ScryptEncoder();
                    if (encrypt.Compare(user.Password, userExist.MyPassword))
                    {
                        HttpContext.Session.SetInt32("UserId", userExist.Id);
                        HttpContext.Session.SetString("Name", userExist.FirstName);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username/Password Is Wrong");
                    return View();
                }
            }
            ModelState.AddModelError("", "Something Went Wrong Retry");
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Locations = Locations.Cities;
            ViewBag.Genders = Genders.Types;
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var userExist = _context.PortalUser.Where(x => x.UserName.ToLower().Equals(user.UserName.ToLower())).FirstOrDefault();
                if (userExist == null)
                {
                    ScryptEncoder encrypt = new ScryptEncoder();
                    User newUser = new User();
                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.MyLocation = user.Location;
                    newUser.DOB = user.DOB;
                    newUser.Gender = user.Gender;
                    newUser.UserName = user.UserName;
                    newUser.PhoneNumber = user.PhoneNumber;
                    
                    newUser.MyPassword = encrypt.Encode(user.Password);
                    _context.PortalUser.Add(newUser);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Users");
                }
                ModelState.AddModelError("", "Usename Already Exist");
                ViewBag.Locations = Locations.Cities;
                ViewBag.Genders = Genders.Types;
                return View();
            }
            ModelState.AddModelError("", "Something Went Wrong Retry");
            ViewBag.Genders = Genders.Types;
            ViewBag.Locations= Locations.Cities;
            return View(user);
        }
        public IActionResult Details()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "Users");
            var user = _context.PortalUser.Find(HttpContext.Session.GetInt32("UserId"));
            return View(user);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
