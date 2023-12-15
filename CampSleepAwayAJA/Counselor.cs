

namespace CampSleepAwayAJA
{
    public class Counselor
    {
        public int CounselorID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Cabin? Cabin { get; set; }
        public int? CabinID { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int ContactInfoID { get; set; }
    }
}
