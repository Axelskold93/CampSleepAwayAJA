using Spectre.Console;

/*Class for console display methodes*/
namespace CampSleepAwayAJA
{
	public class ManageConsole
	{
		public void MainMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
					  .Title("Main Menu")
					  .AddChoices(new[] { "Manage", "Reports", "Exit" })
					  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Manage"))
				{
					ManageMenu();
				}
				else if (menu.Contains("Reports"))
				{
					ReportsMenu();
				}
				else if (menu.Contains("Exit"))
				{
					Environment.Exit(0);
				}
			}

		}
		public void ManageMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
				  .Title("Manage Menu")
				  .AddChoices(new[] { "Counselors", "Cabins", "Campers", "Exit" })
				  .UseConverter(s => s.ToUpperInvariant()));


				if (menu.Contains("Counselors"))
				{
					ManageCounselorMenu();
				}
				else if (menu.Contains("Cabins"))
				{
					ManageCabinMenu();
				}
				else if (menu.Contains("Campers"))
				{
					ManageCamperMenu();
				}
				else if (menu.Contains("Exit"))
				{
					break;
				}

			}
		}
		public void ManageCounselorMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
					  .Title("Counselor Menu")
					  .AddChoices(new[] { "Add Counselor", "Remove Counselor", "Update Counselor", "View Counselors", "Exit" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Add Counselor"))
				{
					ManageDatabase.AddCounselor();
				}
				else if (menu.Contains("Remove Counselor"))
				{
					ManageDatabase.RemoveCounselor();
				}
				else if (menu.Contains("Update Counselor"))
				{
					ManageDatabase.UpdateCounselor();
				}
				else if (menu.Contains("View Counselors"))
				{
					ManageDatabase.ViewCounselors();
				}
				else if (menu.Contains("Exit"))
				{
					break;
				}
			}
		}
		public void ManageCabinMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
					  .Title("Cabin Menu")
					  .AddChoices(new[] { "Add Cabin", "Remove Cabin", "Update Cabin", "View Cabins", "Exit" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Add Cabin"))
				{
					ManageDatabase.AddCabin();
				}
				else if (menu.Contains("Remove Cabin"))
				{
					ManageDatabase.RemoveCabin();
				}
				else if (menu.Contains("Update Cabin"))
				{
					ManageDatabase.UpdateCabin();
				}
				else if (menu.Contains("View Cabins"))
				{
					ManageDatabase.ViewCabins();
				}
				else if (menu.Contains("Exit"))
				{
					break;
				}
			}
		}
		public void ManageCamperMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
					   .Title("Camper Menu")
					   .AddChoices(new[] { "Add Camper", "Remove Camper", "Update Camper", "View Campers", "Exit" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Add Camper"))
				{
					ManageDatabase.AddCamper();
				}
				else if (menu.Contains("Remove Camper"))
				{
					ManageDatabase.RemoveCamper();
				}
				else if (menu.Contains("Update Camper"))
				{
					ManageDatabase.UpdateCamper();
				}
				else if (menu.Contains("View Campers"))
				{
					ManageDatabase.ViewCampers();
				}
				else if (menu.Contains("Exit"))
				{
					break;
				}
			}
		}

		public void ReportsMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
				  .Title("Reports Menu")
				  .AddChoices(new[] { "Counselors", "Cabins", "Campers", "Exit" })
					.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Counselors"))
				{
					CounselorMenu();
				}
				else if (menu.Contains("Cabins"))
				{
					CabinMenu();
				}
				else if (menu.Contains("Campers"))
				{
					CamperMenu();
				}
				else if (menu.Contains("Exit"))
				{
					break;
				}

			}
		}
		public void CounselorMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
									 .Title("Counselor Menu")
									.AddChoices(new[] { "View Counselors", "View Counselors by Cabin", "Exit" })
									.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("View Counselors"))
				{
					ManageDatabase.ViewCounselors();
				}
				//else if (menu.Contains("View Counselors by Cabin"))
				//{
				//    ManageDatabase.ViewCounselorsByCabin();
				//}
				else if (menu.Contains("Exit"))
				{
					break;
				}

			}
		}
		public void CabinMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
						   .Title("Cabin Menu")
						   .AddChoices(new[] { "View Cabins", "View Cabins by Counselor", "Exit" })
							.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("View Cabins"))
				{
					ManageDatabase.ViewCabins();
				}
				//else if (menu.Contains("View Cabins by Counselor"))
				//{
				//    ManageDatabase.ViewCabinsByCounselor();
				//}
				else if (menu.Contains("Exit"))
				{
					break;
				}

			}
		}
		public void CamperMenu()
		{
			while (true)
			{
				var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
				  .Title("Camper Menu")
				  .AddChoices(new[] { "View Campers", "View Campers by Cabin", "Exit" })
																																																																																																																																																																																							  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("View Campers"))
				{
					ManageDatabase.ViewCampers();
				}
				//else if (menu.Contains("View Campers by Cabin"))
				//{
				//    ManageDatabase.ViewCampersByCabin();
				//}
				else if (menu.Contains("Exit"))
				{
					break;
				}

			}
		}
	}
}
