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
            }
        }
    }
}
