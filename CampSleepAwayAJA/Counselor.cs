

namespace CampSleepAwayAJA
{
    public class Counselor
    {
        public int CounselorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Cabin Cabin { get; set; }
        public int? CabinID { get; set; }

        public CounselorInfo CounselorInfo { get; set; }
        public int CounselorInfoID { get; set; }
    }
}
