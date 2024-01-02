

using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
	public class NextOfKin : Person
	{
		[Column(Order = 1)]
		public int NextOfKinID { get; set; }
		public string Relation { get; set; }
		public Camper Camper { get; set; }
		[ForeignKey("ContactInfoId")]
		public ContactInfo ContactInfo { get; set; }
	}
}