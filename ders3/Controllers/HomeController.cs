using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ders3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            XmlDocument xml = new XmlDocument();

            xml.Load(Server.MapPath("\\App_Data\\db.xml"));
            var admin = xml.SelectSingleNode(@"/admin");

            var name = admin.SelectSingleNode("name").InnerText;
            var password = admin.SelectSingleNode("password").InnerText;

            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["username"] == name && Request.Form["password"] == password)
                {
                    return Redirect("/Panel/Index");
                }

                ViewBag.GirisBasarisiz = true;
            }

            return View();
        }
    }
}