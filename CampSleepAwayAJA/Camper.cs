

using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
    public class Camper : Person
    {
        [Column(Order = 1)]
        public int CamperID { get; set; }
        public DateTime StartDate { get; set; }
        public   DateTime EndDate { get; set; }
        public ICollection <NextOfKin>? NextOfKin { get; set; }
        
        public Cabin Cabin { get; set; }
        public int? CabinID { get; set; }
    }
}
