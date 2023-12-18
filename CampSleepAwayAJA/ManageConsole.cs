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
                      .AddChoices(new[] {"Manage", "Reports", "Exit"})
                      .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("MANAGE"))
                {
                    ManageMenu();
                }
                else if (menu.Contains("REPORTS"))
                {
                    ReportsMenu();
                }
                else if (menu.Contains("EXIT"))
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
                  .AddChoices(new[] {"Counselors", "Cabins", "Campers"})
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
               
            }
        }
        public void ManageCounselorMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                      .Title("Counselor Menu")
                      .AddChoices(new[] {"Add Counselor", "Remove Counselor", "Update Counselor", "View Counselors"})
                                                                                                                                                                                                                                                      .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("ADD COUNSELOR"))
                {
                    ManageDatabase.AddCounselor();
                }
                else if (menu.Contains("REMOVE COUNSELOR"))
                {
                    ManageDatabase.RemoveCounselor();
                }
                else if (menu.Contains("UPDATE COUNSELOR"))
                {
                    ManageDatabase.UpdateCounselor();
                }
                else if (menu.Contains("VIEW COUNSELORS"))
                {
                    ManageDatabase.ViewCounselors();
                }
            }
        }
        public void ManageCabinMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                      .Title("Cabin Menu")
                      .AddChoices(new[] {"Add Cabin", "Remove Cabin", "Update Cabin", "View Cabins"})
                                                                                                                                                                                                                                                                                                                                                 .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("ADD CABIN"))
                {
                    ManageDatabase.AddCabin();
                }
                else if (menu.Contains("REMOVE CABIN"))
                {
                    ManageDatabase.RemoveCabin();
                }
                else if (menu.Contains("UPDATE CABIN"))
                {
                    ManageDatabase.UpdateCabin();
                }
                else if (menu.Contains("VIEW CABINS"))
                {
                    ManageDatabase.ViewCabins();
                }
            }
        }
        public void ManageCamperMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                       .Title("Camper Menu")
                       .AddChoices(new[] {"Add Camper", "Remove Camper", "Update Camper", "View Campers"})
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
                else if (menu.Contains("VIEW CAMPERS"))
                {
                    ManageDatabase.ViewCampers();
                }
            }
        }
        
        public void ReportsMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                  .Title("Reports Menu")
                  .AddChoices(new[] {"Counselors", "Cabins", "Campers"})
                                                                                                                                                                                                                                                                                                                                    .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("COUNSELORS"))
                {
                    CounselorMenu();
                }
                else if (menu.Contains("CABINS"))
                {
                    CabinMenu();
                }
                else if (menu.Contains("CAMPERS"))
                {
                    CamperMenu();
                }
                
            }
        }
        public void CounselorMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                                     .Title("Counselor Menu")
                                                      .AddChoices(new[] {"View Counselors", "View Counselors by Cabin"})
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("VIEW COUNSELORS"))
                {
                    ManageDatabase.ViewCounselors();
                }
                else if (menu.Contains("VIEW COUNSELORS BY CABIN"))
                {
                    ManageDatabase.ViewCounselorsByCabin();
                }
                
            }
        }
        public void CabinMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                           .Title("Cabin Menu")
                           .AddChoices(new[] {"View Cabins", "View Cabins by Counselor"})
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("VIEW CABINS"))
                {
                    ManageDatabase.ViewCabins();
                }
                else if (menu.Contains("VIEW CABINS BY COUNSELOR"))
                {
                    ManageDatabase.ViewCabinsByCounselor();
                }
                
            }
        }
        public void CamperMenu()
        {
            while (true)
            {
                var menu = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                  .Title("Camper Menu")
                  .AddChoices(new[] {"View Campers", "View Campers by Cabin"})
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              .UseConverter(s => s.ToUpperInvariant()));

                if (menu.Contains("VIEW CAMPERS"))
                {
                    ManageDatabase.ViewCampers();
                }
                else if (menu.Contains("VIEW CAMPERS BY CABIN"))
                {
                    ManageDatabase.ViewCampersByCabin();
                }
                
            }
        }
    }
}
