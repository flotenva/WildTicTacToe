namespace WildTicTacToe
{
    public class ComputerPlayer : Player
    {
        private Random random = new Random();

        public override void MakeMove(Board board)
        {
            int row = 0, col = 0;
            char piece = ' ';

            bool validMove = false;

            // Generate random moves until a valid move is found
            while (!validMove)
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
                piece = random.Next(0, 2) == 0 ? 'X' : 'O';

                // Uses the board's IsValidMove method to check if the move is valid
                if (board.IsValidMove(row, col, piece))
                {
                    board.MakeMove(row, col, piece);
                    validMove = true;
                }
            }
        }
    }
}
