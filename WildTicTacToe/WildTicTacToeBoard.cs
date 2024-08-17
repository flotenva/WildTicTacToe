namespace WildTicTacToe
{
    public class WildTicTacToeBoard : Board
    {
        private char[,] board;

        public WildTicTacToeBoard()
        {
            board = new char[3, 3];
            InitialiseBoard();
        }

        // Set up a 3x3 game board and fill it with empty spaces
        public override void InitialiseBoard()
        {
            for (int r = 0; r < 3; r++) // Iterate over rows
            {
                for (int c = 0; c < 3; c++) // Iterate over columns
                {
                    board[r, c] = ' '; // Fill board slots with empty spaces
                }
            }
        }

        // Check if a move is valid
        public override bool IsValidMove(int row, int col, char piece)
        {
            bool condition1 = row >= 0 && row < 3; // Check if the row is within the board's boundaries
            bool condition2 = col >= 0 && col < 3; // Check if the column is within the board's boundaries
            bool condition3 = board[row, col] == ' '; // Check if the slot is empty
            bool condition4 = piece == 'X' || piece == 'O'; // Check if the piece is either 'X' or 'O'

            return condition1 && condition2 && condition3 && condition4;
        }

        // Overwrite the board slot with the player's move
        public override void UpdateBoard(int row, int col, char piece)
        {
            if (IsValidMove(row, col, piece))
            {
                board[row, col] = piece;
            }
        }

        // Check if the game meets the winning conditions
        // in WildTicTacToe, the player wins if they have the same three pieces in a row, column, or diagonal
        public override bool CheckWin()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }

        private bool CheckRows()
        {
            // It iterates over the rows and checks if: 
            // condition1 = the slot is not empty, and 
            // condition2 = if the row has the same piece in all three columns
            for (int r = 0; r < 3; r++)
            {
                bool condition1 = board[r, 0] != ' ';
                bool condition2 = board[r, 0] == board[r, 1] && board[r, 1] == board[r, 2];

                if (condition1 && condition2)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumns()
        {
            // It iterates over the columns and checks if:
            // condition1 = the slot is not empty, and
            // condition2 = if the column has the same piece in all three rows
            for (int c = 0; c < 3; c++)
            {
                bool condition1 = board[0, c] != ' ';  
                bool condition2 = board[0, c] == board[1, c] && board[1, c] == board[2, c]; 

                if (condition1 && condition2)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonals()
        {
            // It checks if the diagonals have the same piece in all three slots
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }
            return false;
        }

        public override void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int r = 0; r < 3; r++)
            {
                Console.Write(r + " ");
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(board[r, c]);
                    if (c < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (r < 2) Console.WriteLine("  -----");
            }
            Console.WriteLine();
        }

        public override char GetPiece(int row, int col)
        {
            return board[row, col];
        }

        public override void SetPiece(int row, int col, char piece)
        {
            board[row, col] = piece;
        }
    }
}