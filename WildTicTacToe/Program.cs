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
                        Game.InitialiseGame();
                        break;
                    case 2:
                        // Load Game
                        break;
                    case 3:
                        Menu.DisplayInstructions();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again.\n");
                        break;
                }
            } while (true);
        }
    }
}
