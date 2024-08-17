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
                board.DisplayBoard();
                // Get the row from player
                do
                {
                    Console.Write("Enter row number (0, 1, or 2): ");
                } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2);

                // Get the column from player
                do
                {
                    Console.Write("Enter column number (0, 1, or 2): ");
                } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2);

                // Get the piece from player
                do
                {
                    Console.Write("Enter piece (X or O): ");
                    string input = Console.ReadLine().ToUpper();

                    if (!string.IsNullOrEmpty(input) && (input == "X" || input == "O"))
                    {
                        piece = input[0];
                    }
                    else
                    {
                        piece = '\0'; // Reset piece to an invalid value to continue the loop
                    }
                } while (piece != 'X' && piece != 'O');


                if (board.IsValidMove(row, col, piece))
                {
                    board.MakeMove(row, col, piece);
                    validMove = true;
                }
                else
                {
                    Menu.CountDownMessage("Invalid move.", 3);
                }
            }
        }
    }
}
