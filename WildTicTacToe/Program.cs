namespace WildTicTacToe
{
    class Program
    {
        public static void Main()
        {
            Menu.DisplayWelcome();      // Welcome message
            Menu.DisplayMainOptions();  // Display main options
            do
            {
                Menu.DisplayWelcome();
                Console.WriteLine("Select an option:");
                Menu.DisplayMainOptions();
                
                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        // Start new game
                        Game.InitialiseNewGame();
                        break;
                    case 2:
                        // Load game
                        Game.LoadGame();
                        break;
                    case 3:
                        // Exit game
                        Console.WriteLine("Exiting the game. Goodbye!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                        break;
                    default:
                        Menu.CountDownMessage("Invalid option.", 3);
                        break;
                }
            } while (true);
        }
    }
}
