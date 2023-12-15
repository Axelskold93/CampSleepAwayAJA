

namespace CampSleepAwayAJA
{

    public class NextOfKin
    {
        public int NextOfKinID { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }

        public Camper Camper { get; set; }
        public int? CamperID { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public  int? ContactInfoID { get; set; }
        public Counselor Counselor { get; set; }
        public int? CounselorID { get; set; }
        
    }

	

}
