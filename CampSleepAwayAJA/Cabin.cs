using System.ComponentModel.DataAnnotations;

namespace CampSleepAwayAJA

{
	public class Cabin
	{
		public int CabinID { get; set; }
		public required string CabinName { get; set; }

		[Range(0, 4, ErrorMessage = "Maximum capacity reached.")]
		public int CabinCapacity { get; set; }

		public ICollection<Camper>? Campers { get; set; }
		public Counselor? Counselor { get; set; }

		public int? CounselorID { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}