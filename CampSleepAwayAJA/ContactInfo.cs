using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAwayAJA
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Camper Camper { get; set; }
        public Counselor Counselor { get; set; }
        public NextOfKin NextOfKin { get; set; }
    }
}
