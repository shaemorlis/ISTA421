using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peoples.Models;
namespace Peoples.Controllers
{
    public class HomeController : Controller
    {
        PeopleContext peopleContext = new PeopleContext();
        public ActionResult Index()
        {
            /// createMyFamily();
            initlizeMyFamily();

           // People p = peopleContext.Peoples.Where(x => x.familyName.Equals("Richareds")).FirstOrDefault();
            
            return View(peopleContext.Persons.Where(x=>x.familyNumber.Equals(1)));
        }

        public void initlizeMyFamily()
        {
            Person me = new Person();

            
            me.PersonAge = 32;
            me.PersonEmail = "Shae@gmail.com";
            me.PersonAddress = "New York ";
            me.PersonName = "Shae";
            me.PersonState = "NY";
            me.familyNumber= peopleContext.Peoples.Where(x => x.familyName.Equals("Richareds")).FirstOrDefault().familyNumber;


            Person Steven = new Person();
            
            Steven.PersonAge = 32;
            Steven.PersonEmail = "Steven@gmail.com";
            Steven.PersonAddress = "New York ";
            Steven.PersonName = "Steven";
            Steven.PersonState = "NY";
            Steven.familyNumber = peopleContext.Peoples.Where(x => x.familyName.Equals("Richareds")).FirstOrDefault().familyNumber;

            Person Dwayne = new Person();

            Dwayne.PersonAge = 36;
            Dwayne.PersonEmail = "Dwayne@gmail.com";
            Dwayne.PersonAddress = "New York ";
            Dwayne.PersonName = "Dwayne";
            Dwayne.PersonState = "NY";
            Dwayne.familyNumber = peopleContext.Peoples.Where(x => x.familyName.Equals("Richareds")).FirstOrDefault().familyNumber;

            //adding persons to family
            peopleContext.Persons.Add(me);
            peopleContext.Persons.Add(Steven);
            peopleContext.Persons.Add(Dwayne);

            try
            {
                peopleContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Message : "+ex.Message+"\n Ex to string: " +ex.ToString());
            }
            catch (Exception e )
            {
                Console.WriteLine("Message : " + e.Message + "\n Ex to string: " + e.ToString());

            }
           
        }

        public void createMyFamily()
        {
            People myFamily = new People();
            myFamily.familyName = "Richareds";
            peopleContext.Peoples.Add(myFamily);
            peopleContext.SaveChanges();

        }

        public ActionResult Search( string SearchString)
        {

            if (SearchString==null || SearchString.Equals(""))
            {
                return View("index",peopleContext.Persons.Where(x => x.familyNumber.Equals(1)));
            }

            return View("index",peopleContext.Persons.Where(x => x.PersonName.Contains(SearchString)));

        }
        
    }
}