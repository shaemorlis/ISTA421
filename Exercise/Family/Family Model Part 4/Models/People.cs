using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Peoples.Models
{
    [Table("People")]
    public class People
    {

        
        [Key]
        public int familyNumber { get; set; }
        public string familyName { get;  set; }
      
        public ICollection<Person> Persons { get; set; }
    }
}