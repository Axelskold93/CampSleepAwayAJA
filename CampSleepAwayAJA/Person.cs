using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAwayAJA
{
    public class Person
    {
        [Column(Order = 2)]
        public string FirstName { get; set; }
        [Column(Order = 3)]
        public string LastName { get; set; }
    }
}
