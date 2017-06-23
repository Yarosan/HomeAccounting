﻿using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MenuBarController : Controller
    {
        [OutputCache(Duration = 120)]
        public ActionResult Index()
        {
            return PartialView("_MenuBar");
        }
    }
}