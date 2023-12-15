

namespace CampSleepAwayAJA
{
    public class Counselor
    {
        public int CounselorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Cabin? Cabin { get; set; }
        public int? CabinID { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int ContactInfoID { get; set; }
    }
}
