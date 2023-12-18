using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepAwayAJA
{
	public class CSAContext : DbContext
	{

		

		public DbSet<Cabin> Cabins { get; set; }
		public DbSet<Camper> Campers { get; set; }
		public DbSet<Counselor> Counselors { get; set; }
		public DbSet<NextOfKin> NextOfKins { get; set; }
		public DbSet<ContactInfo> ContactInfos { get; set; }
		


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

			var connectionString = configuration.GetConnectionString("Local");

			optionsBuilder.UseSqlServer(connectionString)
				.LogTo(Console.WriteLine,
				new[] { DbLoggerCategory.Database.Name },
				LogLevel.Information)
				.EnableSensitiveDataLogging();
		}
	}
}