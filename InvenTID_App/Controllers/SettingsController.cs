using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvenTID_App.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult CookiesSet(FormCollection parametres)
        {
            try
            {
                //string u = parametres["u"];
                //int p;
                //Int32.TryParse(parametres["p"], out p);
                //string k = parametres["k"];

                //HttpCookie port = new HttpCookie("port");
                //port.Value = p.ToString;
                //port.Expires = DateTime.Now.AddMonths(1);
                //Response.Cookies.Add(port);

                //HttpCookie username = new HttpCookie()



                return Json(new
                {
                    Message = "Le port de communication a bien été configuré !",
                    Html = "",
                    Status = 0
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new
                {
                    Message = "Echec !",
                    Html = "",
                    Status = 0
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(true);
        
        }
    }
}