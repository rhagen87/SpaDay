using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/user/add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("/user/add")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            if (verify == newUser.Password)
            {
                ViewBag.Username = newUser.Username;
                return View("Index");
            }
            else
            {
                ViewBag.Username = newUser.Username;
                ViewBag.Email = newUser.Email;
                ViewBag.Error = "Please enter matching passwords.";
                return View("Add");
            }
        }
    }
}
