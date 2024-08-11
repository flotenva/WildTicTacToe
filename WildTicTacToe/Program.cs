namespace WildTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            // Welcome message
            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("## IFQ563 Object Oriented Design ##");
            Console.WriteLine("## Assignment 2: Implementation  ##");
            Console.WriteLine("###################################\n");
            Console.WriteLine("###################################");
            Console.WriteLine("## Welcome to Wild Tic Tac Toe!  ##");
            Console.WriteLine("###################################\n");

            PlayGame(board);
        }

        static void PlayGame(Board board)
        {
            Player player1 = null;
            Player player2 = null;
            bool gameWon = false;
            int gameTurn = 0;
            int mode;

            // Menu with available game modes
            do
            {
                Console.WriteLine("Select game mode:");
                Console.WriteLine("1. Human vs Human");
                Console.WriteLine("2. Computer vs Human");
                int.TryParse(Console.ReadLine(), out mode);

                switch (mode)
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
            } while (mode != 1 && mode != 2);

            
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
                string winner = (gameTurn % 2 == 0) ? "Player 2" : "Player 1";
                Console.WriteLine($"Congratulations! {winner} is the winner of the WildTicTacToe game!");
            }
            else
            {
                Console.WriteLine("Oops. It's a draw!");
            }
        }
    }
}
