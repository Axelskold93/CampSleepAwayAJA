﻿using Spectre.Console;

/*Class for console display methodes*/
namespace CampSleepAwayAJA
{
	public class ManageConsole
	{
		public void MainMenu()
		{
			
			while (true)
			{
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("Main Menu")
					  .AddChoices(new[] { "Manage", "View", "Exit" })
					  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Manage"))
				{
					ManageMenu();
				}
				else if (menu.Contains("View"))
				{
					ViewMenu();
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
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				  .Title("Manage Menu")
				  .AddChoices(new[] { "Counselors", "Cabins", "Campers", "Back" })
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
				else if (menu.Contains("Back"))
				{
					break;
				}

			}
		}
		public void ManageCounselorMenu()
		{ 
			
			while (true)
			{
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("Counselor Menu")
					  .AddChoices(new[] { "Add Counselor", "Remove Counselor", "Update Counselor", "Back" })
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
				else if (menu.Contains("Back"))
				{
					break;
				}
			}
		}
		public void ManageCabinMenu()
		{
		    while (true)
			{
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("Cabin Menu")
					  .AddChoices(new[] { "Add Cabin", "Update Cabin", "Remove Cabin", "Back" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Add Cabin"))
				{
					ManageDatabase.AddCabin();
				}
				else if (menu.Contains("Update Cabin"))
				{
					ManageDatabase.UpdateCabin();
				}
				else if (menu.Contains("Remove Cabin"))
				{
					ManageDatabase.RemoveCabin();
				}
				else if (menu.Contains("Back"))
				{
					break;
				}
			}
		}
		public void ManageCamperMenu()	
		{		
			while (true)
			{
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					   .Title("Camper Menu")
					   .AddChoices(new[] { "Add Camper", "Remove Camper", "Update Camper", "Back" })
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
				else if (menu.Contains("Back"))
				{
					break;
				}
			}
		}

		public void ViewMenu()
		{
			while (true)
			{
                Console.Clear();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				  .Title("View Menu")
				  .AddChoices(new[] { "Counselors", "Cabins", "Campers", "Back" })
					.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Counselors"))
				{
					ManageDatabase.ViewCounselors();
				}
				else if (menu.Contains("Cabins"))
				{
					ManageDatabase.ViewCabins();
				}
				else if (menu.Contains("Campers"))
				{
                    ManageDatabase.ViewCampers();
                }
				else if (menu.Contains("Back"))
				{
					break;
				}

			}
		}

	}
}

