using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepAwayAJA
{
	public class CSAContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<EmployeeProfile> EmployeesProfile { get; set; }
		public DbSet<Skill> Skills { get; set; }

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