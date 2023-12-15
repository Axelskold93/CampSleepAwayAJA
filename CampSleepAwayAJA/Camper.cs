

namespace CampSleepAwayAJA
{
    public class Camper
    {
        public int CamperID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public ICollection <NextOfKin> NextOfKin { get; set; }
        public required int NextOfKinID { get; set; }

        public Cabin Cabin { get; set; }
        public int CabinID { get; set; }
    }
}
