namespace WildTicTacToe
{
    public class HumanPlayer : Player
    {
        public override void MakeMove(Board board)
        {
            int row, col;
            char piece;
            bool validMove = false;

            while (!validMove)
            {
                Menu.DisplayGameOptions();
                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        board.DisplayBoard();
                        
                        Console.Write("Enter row (0, 1, or 2): ");
                        row = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter column (0, 1, or 2): ");
                        col = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter piece (X or O): ");
                        piece = Convert.ToChar(Console.ReadLine().ToUpper());

                        if (board.IsValidMove(row, col, piece))
                        {
                            board.MakeMove(row, col, piece);
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move. Try again.");
                        }
                        break;
                    case 2:
                        Menu.DisplayInstructions();
                        break;
                    case 3:
                        // Save game
                        break;
                    case 4:
                        // Quit game and return to main menu
                        Program.Main(null);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}