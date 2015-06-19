using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using asp_net_mvc_localization.Models;

namespace asp_net_mvc_localization.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            Account tUser = new Account();
            return View(tUser);
        }

        public ActionResult Create(Account tUser)
        {
            if (ModelState.IsValid)
                return Redirect("/");
            return View(tUser);
        }

        public ActionResult Table()
        {
            List<Account> list = new List<Account>();
         
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new Account()
                {
                    Age = 18+i,
                    Email = "email"+i+"@gmail.com",
                    Username = "name" + i,
                    Birthday = DateTime.Today,
                    Password = "password" + i,
                    Rand = i + 1
                });
            }
            
            return View(list);
        }

        public ActionResult DateExample()
        {
            return View();
        }

        public string Test()
        {
            return ErrorCodeToString(MembershipCreateStatus.DuplicateUserName);
        }
    }
}