using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
	public class Person
	{
        [Column(Order = 2)]
        [Required]
        public string FirstName { get; set; }

        [Column(Order = 3)]
		[Required]
		public string LastName { get; set; }
		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";
	}
}