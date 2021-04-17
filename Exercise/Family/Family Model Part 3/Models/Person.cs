using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peoples.Models
{
    public class Person
    {
        [Key]
        public int PersonID { set; get; }
        public string PersonName { set; get; }
        public int PersonAge { set; get; }
        public string PersonEmail { set; get; }
        public string PersonAddress { set; get; }
        public string PersonState { set; get; }

        public string PersonFamily{ set; get; }
        public int familyNumber { set; get; }

        
    }
}