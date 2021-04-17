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
            //DeleteAllRecords();
            //createMyFamily();
            //initlizeMyFamily();

            // People p = peopleContext.Peoples.Where(x => x.familyName.Equals("Morlis")).FirstOrDefault();

            //var result = from people in peopleContext.Peoples join person in peopleContext.Persons on people.familyNumber equals person.familyNumber into matchedResults select { Person = person};


        var result2 = (from m1 in peopleContext.Peoples
                      join m2 in peopleContext.Persons
                       on new { m1.familyNumber }
                       equals new { m2.familyNumber }
                      select new
                      {
                          PersonFamily = m1.familyName,
                          PersonName = m2.PersonName,
                          PersonAge = m2.PersonAge,
                          PersonEmail = m2.PersonEmail,
                          PersonAddress = m2.PersonAddress,
                          PersonState = m2.PersonState


                      }).ToList();


            List<CustomModel> customModels = new List<CustomModel>();

            foreach ( var x in result2)
            {
                CustomModel model=new CustomModel();

                model.PersonFamily = x.PersonFamily;
                model.PersonName = x.PersonName;
                model.PersonAge = x.PersonAge;
                model.PersonEmail = x.PersonEmail;
                model.PersonAddress = x.PersonAddress;
                model.PersonState = x.PersonState;

                customModels.Add(model);
            }
            return View(customModels);
        }

        public void initlizeMyFamily()
        {
            Person me = new Person();

            
            me.PersonAge = 32;
            me.PersonEmail = "Shae@gmail.com";
            me.PersonAddress = "New York ";
            me.PersonName = "Shae";
            me.PersonState = "NY";
            me.familyNumber= peopleContext.Peoples.Where(x => x.familyName.Equals("Morlis")).FirstOrDefault().familyNumber;


            Person Steven = new Person();
            
            Steven.PersonAge = 32;
            Steven.PersonEmail = "Steven@gmail.com";
            Steven.PersonAddress = "New York ";
            Steven.PersonName = "Steven";
            Steven.PersonState = "NY";
            Steven.familyNumber = peopleContext.Peoples.Where(x => x.familyName.Equals("Lowe")).FirstOrDefault().familyNumber;

            Person Dwayne = new Person();

            Dwayne.PersonAge = 36;
            Dwayne.PersonEmail = "Dwayne@gmail.com";
            Dwayne.PersonAddress = "New York ";
            Dwayne.PersonName = "Dwayne";
            Dwayne.PersonState = "NY";
            Dwayne.familyNumber = peopleContext.Peoples.Where(x => x.familyName.Equals("Lowe")).FirstOrDefault().familyNumber;

            Person Davion = new Person();

            Davion.PersonAge = 34;
            Davion.PersonEmail = "Dwayne@gmail.com";
            Davion.PersonAddress = "New York ";
            Davion.PersonName = "Dwayne";
            Davion.PersonState = "NY";
            Davion.familyNumber = peopleContext.Peoples.Where(x => x.familyName.Equals("Lowe")).FirstOrDefault().familyNumber;

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
            People Lowe = new People();
            Lowe.familyName = "Lowe";
            peopleContext.Peoples.Add(Lowe);

            People Morlis = new People();
            Morlis.familyName = "Morlis";
            peopleContext.Peoples.Add(Morlis);

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

        public ActionResult AddNewPerson()
        {

            var x = peopleContext.Peoples.ToList();
            ViewBag.PeopleFamily = new SelectList(x, "familyNumber", "familyName");
            return View("AddNewPerson");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPerson([Bind(Include = "PersonName,PersonAge,PersonEmail,PersonAddress, PersonState")] Person person, int PeopleFamily)
        {
            if (ModelState.IsValid)
            {
                person.familyNumber = peopleContext.Peoples.Where(x=>x.familyNumber.Equals(PeopleFamily)).FirstOrDefault().familyNumber; 
                peopleContext.Persons.Add(person);
               
                peopleContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("index");
            
        }

        public void DeleteAllRecords()
        {
           foreach( People p in peopleContext.Peoples)
            {
                peopleContext.Peoples.Remove(p);
            }

            foreach (Person  p in peopleContext.Persons)
            {
                peopleContext.Persons.Remove(p);
            }
        }
    }
}