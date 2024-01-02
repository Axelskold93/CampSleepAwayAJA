using Spectre.Console;
/*Class for console display methodes*/
namespace CampSleepAwayAJA
{
	public class ManageConsole
	{
		public static void MainMenu()
		{
			while (true)
			{
                Console.Clear();
                DisplayHeader();

                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("MAIN MENU")
					  .HighlightStyle(Color.Green3)
					  .AddChoices(new[] { "MANAGE", "VIEW", "SETTINGS", "EXIT" })
					  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("MANAGE"))
				{
					ManageMenu();
				}
				else if (menu.Contains("VIEW"))
				{
					ViewMenu();
				}
				else if (menu.Contains("SETTINGS"))
				{
					ManageDatabase.Settings();
				}
				else if (menu.Contains("EXIT"))
				{
					Environment.Exit(0);
				}
			}
		}
		public static void ManageMenu()
		{
			while (true)
			{
				Console.Clear();
                DisplayHeader();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				  .Title("MANAGE MENU")
				  .HighlightStyle(Color.Green3)
                  .AddChoices(new[] { "COUNSELORS", "CABINS", "CAMPERS", "ADD CAMPER TO CABIN", "BACK" })
				  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("COUNSELORS"))
				{
					ManageCounselorMenu();
				}
				else if (menu.Contains("CABINS"))
				{
					ManageCabinMenu();
				}
				else if (menu.Contains("CAMPERS"))
				{
					ManageCamperMenu();
				}
				else if (menu.Contains("ADD CAMPER TO CABIN"))
				{
					ManageDatabase.AddCamperToCabin();
				}
				else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		public static void ManageCounselorMenu()
		{
			while (true)
			{
				Console.Clear();
                DisplayHeader();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("COUNSELOR MENU")
                      .HighlightStyle(Color.Green3)
                      .AddChoices(new[] { "ADD COUNSELOR", "UPDATE COUNSELOR", "REMOVE COUNSELOR", "BACK" })
					  .UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("ADD COUNSELOR"))
				{
					ManageDatabase.AddCounselor();
				}
				else if (menu.Contains("UPDATE COUNSELOR"))
				{
					ManageDatabase.UpdateCounselor();
				}
				else if (menu.Contains("REMOVE COUNSELOR"))
				{
					ManageDatabase.RemoveCounselor();
				}
				else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		public static void ManageCabinMenu()
		{
			while (true)
			{
				Console.Clear();
                DisplayHeader();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					  .Title("CABIN MENU")
                      .HighlightStyle(Color.Green3)
                      .AddChoices(new[] { "ADD CABIN", "UPDATE CABIN", "REMOVE CABIN", "BACK" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("ADD CABIN"))
				{
					ManageDatabase.AddCabin();
				}
				else if (menu.Contains("UPDATE CABIN"))
				{
					ManageDatabase.UpdateCabin();
				}
				else if (menu.Contains("REMOVE CABIN"))
				{
					ManageDatabase.RemoveCabin();
				}
				else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		public static void ManageCamperMenu()
		{
			while (true)
			{
				Console.Clear();
                DisplayHeader();
                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
					   .Title("CAMPER MENU")
                       .HighlightStyle(Color.Green3)
                       .AddChoices(new[] { "ADD CAMPER", "REMOVE CAMPER", "UPDATE CAMPER", "BACK" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("ADD CAMPER"))
				{
					ManageDatabase.AddCamper();
				}
				else if (menu.Contains("REMOVE CAMPER"))
				{
					ManageDatabase.RemoveCamper();
				}
				else if (menu.Contains("UPDATE CAMPER"))
				{
					ManageDatabase.UpdateCamper();
				}
				else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		public static void ViewMenu()
		{
			while (true)
			{
				Console.Clear();
                DisplayHeader();

                var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				  .Title("VIEW MENU")
                  .HighlightStyle(Color.Green3)
                  .AddChoices(new[] { "COUNSELORS", "CABINS", "CAMPERS", "BACK" })
					.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("COUNSELORS"))
				{
					var data = ManageDatabase.ViewCounselors();
					Table table = new();
					string[] headers = { "FIRST NAME", "LAST NAME", "ADDRESS", "PHONE NUMBER", "EMAIL" };
					table.Title("COUNSELOR VIEW", new Style(Color.Red, Color.Black, Decoration.Bold))
						.AddColumns(headers)
						.Border(TableBorder.Rounded)
						.Expand();
					for (int i = 0; i < data.Count(); i++)
					{
						table.AddRow(
							new Markup($"[blue]{data[i][0]}[/]"),
							new Markup($"[blue]{data[i][1]}[/]"),
							new Markup($"[cyan]{data[i][2]}[/]"),
							new Markup($"[yellow]{data[i][3]}[/]"),
							new Markup($"[green]{data[i][4]}[/]")
							);
						if (i != data.Count() - 1)
						{
							table.AddRow(new Rule(), new Rule(), new Rule(), new Rule(), new Rule());
						}
					}
					AnsiConsole.Write(table);
					Console.ReadLine();
				}
				else if (menu.Contains("CABINS"))
				{
					var data = ManageDatabase.ViewCabins();
					Table table = new();
					string[] headers = { "CABIN NAME", "COUNSELOR NAME", "CAMPERS" };
					table.Title("CABIN VIEW", new Style(Color.Red, Color.Black, Decoration.Bold))
						.AddColumns(headers)
						.Border(TableBorder.DoubleEdge)
						.Width(1000);
					foreach (var row in data)
					{
						List<string> camp = new();
						Table campers = new();
						campers.AddColumn("").HideHeaders().NoBorder();
						for (int i = 2; i < row.Count(); i++)
						{
							campers.AddRow(new Markup($"[Yellow]{row[i]}[/]"));
							campers.AddRow(new Rule());
						}
						table.AddRow(new Markup($"[blue]{row[0]}[/]"), new Markup($"[red]{row[1]}[/]"), campers);
						table.AddRow(new Rule(), new Rule(), new Rule());
					}
					AnsiConsole.Write(table);
					Console.ReadLine();
				}
				else if (menu.Contains("CAMPERS"))
				{
					var data = ManageDatabase.ViewCampers();
					Table table = new();
					string[] headers = { "FULL NAME", "CABIN NAME", "ARRIVAL DATE", "DEPARTURE DATE" };
					table.Title("COUNSELOR VIEW", new Style(Color.Red, Color.Black, Decoration.Bold))
						.AddColumns(headers)
						.Border(TableBorder.Rounded)
						.Width(1000);
					for (int i = 0; i < data.Count(); i++)
					{
						if (data[i][1] != "Not in a cabin")
						{

							table.AddRow(
								new Markup($"[cyan]{data[i][0]}[/]"),
								new Markup($"[green]{data[i][1]}[/]"),
								new Markup($"[yellow]{data[i][2]}[/]"),
								new Markup($"[red]{data[i][3]}[/]")
								);
						}
						else
						{
							table.AddRow(
								new Markup($"[cyan]{data[i][0]}[/]"),
								new Markup($"[red]{data[i][1]}[/]"),
								new Markup($"[red]{data[i][2]}[/]"),
								new Markup($"[red]{data[i][3]}[/]")
								);
						}
						if (i != data.Count() - 1)
						{
							table.AddRow(new Rule(), new Rule(), new Rule(), new Rule());
						}
					}
					AnsiConsole.Write(table);
					Console.ReadLine();
				}
				else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		public static void DisplayHeader()
		{
            AnsiConsole.Write(
                new FigletText("Camp Sleepaway")
                    .LeftJustified()
                    .Color(Color.Green3)
                );
			Console.WriteLine();
        }
	}
}