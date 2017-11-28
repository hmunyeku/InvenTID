﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvenTID_App.Controllers
{
    public class UnauthorisedController : Controller
    {
        // GET: Unauthorised
        public ActionResult Index()
        {    
            return View();
        }

        public ActionResult Error(string _errorMsg)
        {   
            ViewBag.ErrorMsg = _errorMsg;            
            return View();
        }

        public ActionResult Offline()
        {
            return View();
        }  
    }
}