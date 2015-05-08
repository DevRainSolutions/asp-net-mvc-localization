using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using asp_net_mvc_localization.Models;
using System.ComponentModel.DataAnnotations;
using asp_net_mvc_localization.Utils;
using Newtonsoft.Json;

namespace asp_net_mvc_localization.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            User tUser = new User();
            return View(tUser);
        }

        public ActionResult Create(User tUser)
        {
            if (ModelState.IsValid)
                return Redirect("/");
            return View(tUser);
        }

        public ActionResult Table()
        {
            List<User> list = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new User()
                {
                    Age = 18+i,
                    Email = "email"+i+"@gmail.com",
                    Username = "name" + i,
                    Birthday = DateTime.Today,
                    Password = "password" + i,
                    Rand = i
                });
            }
            ViewData["list"] = list;
            return View();
        }

        [HttpGet]
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            var langCookie = new HttpCookie("lang", lang)
            {
                HttpOnly = true
            };
            Response.AppendCookie(langCookie);
            return Redirect(returnUrl);
        }
    }
}