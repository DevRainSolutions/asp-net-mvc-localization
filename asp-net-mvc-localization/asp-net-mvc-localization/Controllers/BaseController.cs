using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_localization.Controllers
{
    public abstract class BaseController : Controller
    {
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