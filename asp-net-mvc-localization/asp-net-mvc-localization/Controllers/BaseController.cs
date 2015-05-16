﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using asp_net_mvc_localization.Resources;
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

        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            Type statusType = createStatus.GetType();
            Type resourceType = typeof (StatusErrors);
            return resourceType.GetProperty(
                statusType.GetEnumName(createStatus)).GetValue(
                new StatusErrors()).ToString();
        }
    }
}