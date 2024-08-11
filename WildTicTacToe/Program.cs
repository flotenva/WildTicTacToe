namespace WildTicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();
            Menu.DisplayWelcome();      // Welcome message
            Menu.DisplayMainOptions();  // Display main options
            do
            {
                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        PlayGame(board);
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

        static void PlayGame(Board board)
        {
            Player player1 = null;
            Player player2 = null;
            bool gameWon = false;
            int gameTurn = 0;
            string gameWinner;
            int gameMode;

            // Select Game Mode
            do
            {
                Menu.DisplayGameMode();
                int.TryParse(Console.ReadLine(), out gameMode);

                switch (gameMode)
                {
                    case 1:
                        player1 = new HumanPlayer();
                        player2 = new HumanPlayer();
                        break;
                    case 2:
                        player1 = new HumanPlayer();
                        player2 = new ComputerPlayer();
                        break;
                    default:
                        Console.WriteLine("Invalid mode selected. Please try again.\n");
                        break;
                }
            } while (gameMode != 1 && gameMode != 2);

            // Start the game
            while (gameTurn < 9 && !gameWon)
            {
                Console.Clear();
                board.DisplayBoard();
                // Alternate between player 1 and player 2
                // When gameTurn is an even number, player1 makes a move
                if (gameTurn % 2 == 0)
                {
                    Console.WriteLine("Player 1's turn:");
                    player1.MakeMove(board);
                }

                // When gameTurn is an odd number, it is player2 turn
                else
                {
                    Console.WriteLine("Player 2's turn:");
                    player2.MakeMove(board);
                }
                gameWon = board.CheckWin();
                gameTurn++;
            }

            Console.Clear();
            board.DisplayBoard();

            if (gameWon)
            {
                gameWinner = (gameTurn % 2 != 0) ? "Player 1" : "Player 2";
                Console.WriteLine($"\nCongratulations! {gameWinner} is the winner of the WildTicTacToe game!");
            }
            else
            {
                Console.WriteLine("Oops. It's a draw!");
            }
            
            // Return to main menu in 3 seconds and show countdown 3,2,1 
            for(int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Returning to main menu in {i}...");
                System.Threading.Thread.Sleep(1000);
            }

            Program.Main(null);
        }
    }
}
