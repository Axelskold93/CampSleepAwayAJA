using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
	public class Camper : Person
	{
		[Column(Order = 1)]
		public int CamperID { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public ICollection<NextOfKin>? NextOfKin { get; set; }
		public Cabin Cabin { get; set; }
		public int? CabinID { get; set; }
	}
}