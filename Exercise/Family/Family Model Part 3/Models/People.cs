using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peoples.Models
{
    public class People
    {

        public List<Person> persons { set; get; }
        [Key]
        public string familyNumber { get; set; }
        public string familyName { get;  set; }
        public People()
        {
            this.persons = new List<Person>();
        }
    }
}