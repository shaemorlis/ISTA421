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

            Person me = new Person();

            me.PersonFamily = "Richareds";
            me.PersonAge = 32;
            me.PersonEmail = "Shae@gmail.com";
            me.PersonAddress = "New York ";
            me.PersonName = "Shae";
            me.PersonState = "NY";

            Person Steven = new Person();
            Steven.PersonFamily = "Richareds";
            Steven.PersonAge = 32;
            Steven.PersonEmail = "Steven@gmail.com";
            Steven.PersonAddress = "New York ";
            Steven.PersonName = "Steven";
            Steven.PersonState = "NY";

            People myFamily = new People();

            myFamily.persons.Add(me);
            myFamily.persons.Add(Steven);

            return View(myFamily);
        }

        
    }
}