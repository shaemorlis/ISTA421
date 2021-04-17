using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Peoples.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonID { set; get; }
        public string PersonName { set; get; }
        public int PersonAge { set; get; }
        public string PersonEmail { set; get; }
        public string PersonAddress { set; get; }
        public string PersonState { set; get; }
        public int familyNumber { set; get; }
       
    }
}