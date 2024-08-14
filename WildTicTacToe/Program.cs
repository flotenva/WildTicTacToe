namespace WildTicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu.DisplayWelcome();      // Welcome message
            Menu.DisplayMainOptions();  // Display main options
            do
            {
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
                        Menu.DisplayWelcome();
                        Menu.DisplayMainOptions();
                        Console.WriteLine("\nInvalid option selected. Please try again.");
                        break;
                }
            } while (true);
        }
    }
}
