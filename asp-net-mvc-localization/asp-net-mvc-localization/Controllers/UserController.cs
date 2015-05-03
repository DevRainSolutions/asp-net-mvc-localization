using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using asp_net_mvc_localization.Models;
using System.ComponentModel.DataAnnotations;
using asp_net_mvc_localization.Utils;

namespace asp_net_mvc_localization.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            TestUser tUser = new TestUser();
            return View(tUser);
        }

        public ActionResult Create(TestUser tUser)
        {
            if (ModelState.IsValid)
                return Redirect("/");
            return View(tUser);
        }
    }
}