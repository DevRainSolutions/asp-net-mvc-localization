﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using asp_net_mvc_localization.Models;
using Newtonsoft.Json;
using Resources;

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
                    Rand = i + 1
                });
            }
            ViewData["list"] = JsonConvert.SerializeObject(list);
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