using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peoples.Models;
namespace Peoples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            MyModel myModel = new MyModel();
            myModel.MyName ="Shae";
            myModel.MyWife = "Caren ";
            myModel.MyBestFriend = "Shawn ";
            myModel.MyBrother1 = "Steven ";
            myModel.MyMother = "Violet";
            myModel.MyFather = "Richard ";
            myModel.MySister = "Aspen";
            return View(myModel);
        }

        
    }
}