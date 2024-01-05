using Spectre.Console;
/*Class for console display methodes*/
namespace CampSleepAwayAJA
{
	public class ConsoleManager
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
					DatabaseManager.Settings();
				}
				else if (menu.Contains("EXIT"))
				{
					Console.Clear();
					Console.Write(boat);
					
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
					DatabaseManager.AddCamperToCabin();
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
					DatabaseManager.AddCounselor();
				}
				else if (menu.Contains("UPDATE COUNSELOR"))
				{
					DatabaseManager.UpdateCounselor();
				}
				else if (menu.Contains("REMOVE COUNSELOR"))
				{
					DatabaseManager.RemoveCounselor();
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
					DatabaseManager.AddCabin();
				}
				else if (menu.Contains("UPDATE CABIN"))
				{
					DatabaseManager.UpdateCabin();
				}
				else if (menu.Contains("REMOVE CABIN"))
				{
					DatabaseManager.RemoveCabin();
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
                       .AddChoices(new[] { "ADD CAMPER", "UPDATE CAMPER", "REMOVE CAMPER", "BACK" })
						.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("ADD CAMPER"))
				{
					DatabaseManager.AddCamper();
				}
                else if (menu.Contains("UPDATE CAMPER"))
                {
                    DatabaseManager.UpdateCamper();
                }
                else if (menu.Contains("REMOVE CAMPER"))
				{
					DatabaseManager.RemoveCamper();
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
                  .AddChoices(new[] { "COUNSELORS", "CABINS", "CAMPERS", "NEXT OF KIN", "BACK" })
					.UseConverter(s => s.ToUpperInvariant()));

				if (menu.Contains("COUNSELORS"))
				{
					DisplayCounslorTable();
                }
				else if (menu.Contains("CABINS"))
				{
					DisplayCabinsTable();
                }
				else if (menu.Contains("CAMPERS"))
				{
					DisplayCamperTable();
                }
				else if (menu.Contains("NEXT OF KIN"))
				{
					//DisplayNextOfKinInfo();
				}
                else if (menu.Contains("BACK"))
				{
					break;
				}
			}
		}
		private static void DisplayCounslorTable()
		{
            var data = DatabaseManager.ViewCounselors();
            Table table = new();
            string[] headers = { "FIRST NAME", "LAST NAME", "ADDRESS", "PHONE NUMBER", "EMAIL" };
            table.Title("COUNSELOR VIEW", new Style(Color.Green, Color.Black, Decoration.Bold))
                .AddColumns(headers)
                .Border(TableBorder.Rounded)
                .Expand();
            for (int i = 0; i < data.Count(); i++)
            {
                table.AddRow(
                    new Markup($"[grey89]{data[i][0]}[/]"),
                    new Markup($"[grey89]{data[i][1]}[/]"),
                    new Markup($"[steelblue3]{data[i][2]}[/]"),
                    new Markup($"[skyblue1]{data[i][3]}[/]"),
                    new Markup($"[steelblue3]{data[i][4]}[/]")
                    );
                if (i != data.Count() - 1)
                {
                    table.AddRow(new Rule(), new Rule(), new Rule(), new Rule(), new Rule());
                }
            }
            AnsiConsole.Write(table);
            Console.ReadLine();
        }
		private static void DisplayCabinsTable()
		{
            var data = DatabaseManager.ViewCabins();
            Table table = new();
            string[] headers = { "CABIN NAME", "COUNSELOR NAME", "CAMPERS" };
            table.Title("CABIN VIEW", new Style(Color.Green, Color.Black, Decoration.Bold))
                .AddColumns(headers)
                .Border(TableBorder.DoubleEdge)
                .Width(1000);
            for (int i = 0; i < data.Count(); i++)
            {
                List<string> camp = new();
                Table campers = new();
                campers.AddColumn("").HideHeaders().NoBorder();
                for (int j = 2; j < data[i].Count(); j++)
                {
                    campers.AddRow(new Markup($"[Yellow]{data[i][j]}[/]"));
					if (j != data[i].Count() - 1)
					{
						campers.AddRow(new Rule());
					}
                }
                table.AddRow(new Markup($"[blue]{data[i][0]}[/]"), new Markup($"[red]{data[i][1]}[/]"), campers);
                if (i != data.Count() - 1)
                {
                    table.AddRow(new Rule(), new Rule(), new Rule());
                }
                
            }
            AnsiConsole.Write(table);
            Console.ReadLine();
        }
		private static void DisplayCamperTable()
		{
            var data = DatabaseManager.ViewCampers();
            Table table = new();
            string[] headers = { "FULL NAME", "CABIN NAME", "ARRIVAL DATE", "DEPARTURE DATE", "NEXT OF KIN" };
            table.Title("CAMPER VIEW", new Style(Color.Green, Color.Black, Decoration.Bold))
                .AddColumns(headers)
                .Border(TableBorder.Rounded)
                .Width(1000);
            for (int i = 0; i < data.Count(); i++)
            {
                Table nextOfKin = new();
                nextOfKin.AddColumn("").HideHeaders().NoBorder();
                for (int j = 4; j < data[i].Count(); j++)
                {
                    nextOfKin.AddRow(new Markup($"[orangered1]{data[i][j]}[/]"));
                    if (j != data[i].Count() - 1)
					{
                        nextOfKin.AddRow(new Rule());
					}
                }
                string arrivalColor = GetDateColor(data[i][2]);
				string departureColor = GetDateColor(data[i][3], true);
                if (data[i][1] != "Not in a cabin")
                {

                    table.AddRow(
                        new Markup($"[grey89]{data[i][0]}[/]"),
                        new Markup($"[green]{data[i][1]}[/]"),
                        new Markup($"[{arrivalColor}]{data[i][2]}[/]"),
                        new Markup($"[{departureColor}]{data[i][3]}[/]"),
						nextOfKin
                        );
                }
                else
                {
                    table.AddRow(
                        new Markup($"[grey70]{data[i][0]}[/]"),
                        new Markup($"[red]{data[i][1]}[/]"),
                        new Markup($"[{arrivalColor}]{data[i][2]}[/]"),
                        new Markup($"[{departureColor}]{data[i][3]}[/]"),
                        nextOfKin
                        );
                }
                if (i != data.Count() - 1)
                {
                    table.AddRow(new Rule(), new Rule(), new Rule(), new Rule(), new Rule());
                }
            }
            AnsiConsole.Write(table);
            Console.ReadLine();
        }
		private static string GetDateColor(string date, bool alt = false)
		{
			string arrivalColor;
			try
			{
                if (DateTime.Parse(date) <= DateTime.Now)
                {
                    arrivalColor = alt ?  "red" : "green";
                }
                else
                {
                    arrivalColor = alt ? "yellow" : "yellow";
                }
				return arrivalColor;
            }
			catch
			{
				return "red";
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
        public static string boat = @"
           ____
              ---|
  \/            /|     \/
               / |\
              /  | \        \/
             /   || \
            /    | | \
           /     | |  \
          /      | |   \
         /       ||     \
        /        /       \
       /________/         \
       ________/__________--/
 ~~~   \___________________/
         ~~~~~~~~~~       ~~~~~~~~
~~~~~~~~~~~~~     ~~~~~~~~~
                               ~~~~~~~~~

";
    }
}