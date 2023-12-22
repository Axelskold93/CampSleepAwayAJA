using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
	public class Person
	{
		[Column(Order = 2)]
		public string FirstName { get; set; }

		[Column(Order = 3)]
		public string LastName { get; set; }
		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";
	}
}