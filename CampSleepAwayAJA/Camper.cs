

namespace CampSleepAwayAJA
{
    public class Camper
    {
        public int CamperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public NextOfKin NextOfKin { get; set; }
        public int NextOfKinID { get; set; }
    }
}
