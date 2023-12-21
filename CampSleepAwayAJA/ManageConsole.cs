using Spectre.Console;
using System.ComponentModel.DataAnnotations;

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
					  .AddChoices(new[] { "Add Counselor", "Update Counselor", "Remove Counselor", "Back" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("Add Counselor"))
				{
					ManageDatabase.AddCounselor();
				}
				else if (menu.Contains("Update Counselor"))
				{
					ManageDatabase.UpdateCounselor();
				}
				else if (menu.Contains("Remove Counselor"))
				{
					ManageDatabase.RemoveCounselor();
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
					//ManageDatabase.AddCamperToCabin();
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
					var data = ManageDatabase.ViewCounselors();
					Table table = new();
					string[] headers = {"First name", "Last name",  "Adress", "Phone number", "Email" };
					table.Title("Counselor View", new Style(Color.Red, Color.Black, Decoration.Bold))
						.AddColumns(headers)
						.Border(TableBorder.Rounded)
						.Width(1000);
					foreach (var row in data)
					{
						table.AddRow(row.ToArray());
					}
					AnsiConsole.Write(table);
					Console.ReadLine();
				}
				else if (menu.Contains("Cabins"))
				{
					var data = ManageDatabase.ViewCabins();
                    Table table = new();
                    string[] headers = { "Cabin Name", "Counselor name", "Campers"};
                    table.Title("Counselor View", new Style(Color.Red, Color.Black, Decoration.Bold))
                        .AddColumns(headers)
                        .Border(TableBorder.Rounded)
                        .Width(1000);
                    foreach (var row in data)
                    {
						List<string> camp = new();
						Table campers = new();
                        campers.AddColumn("").HideHeaders();
                        for (int i = 2; i < row.Count(); i++)
						{
							campers.AddRow(new Markup($"[Yellow]{row[i]}[/],"));
                        }
                        table.AddRow(new Markup($"[blue]{row[0]}[/],"), new Markup($"[red]{row[1]}[/],"), campers);
                    }
                    AnsiConsole.Write(table);
                    Console.ReadLine();
                }
				else if (menu.Contains("Campers"))
				{
                    
                    var data = ManageDatabase.ViewCampers();
                    Table table = new();
                    string[] headers = { "Full name", "Cabin name", "Arrival date", "Departure date"};
                    table.Title("Counselor View", new Style(Color.Red, Color.Black, Decoration.Bold))
                        .AddColumns(headers)
                        .Border(TableBorder.Rounded)
                        .Width(1000);
                    foreach (var row in data)
                    {
                        table.AddRow(row.ToArray());
                    }
                    AnsiConsole.Write(table);
                    Console.ReadLine();
                }
				else if (menu.Contains("Back"))
				{
					break;
				}

			}
		}

	}
}

