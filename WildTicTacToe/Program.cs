class Program
{
    // Create a 3x3 char array to represent the game board
    // The InitialisedBoard method will later fill the board with empty spaces
    static char[,] board = new char[3, 3];
    static int gameTurn = 0;

    static void Main(string[] args)
    {
        // Welcome message
        Console.Clear();
        Console.WriteLine("###################################");
        Console.WriteLine("## IFQ563 Object Oriented Design ##");
        Console.WriteLine("## Assignment 2: Implementation  ##");
        Console.WriteLine("###################################\n");
        Console.WriteLine("###################################");
        Console.WriteLine("## Welcome to Wild Tic Tac Toe!  ##");
        Console.WriteLine("###################################\n");    
        
        InitialiseBoard();
        PlayGame();
    }

// Set up a 3x3 game board and fill it with empty spaces
    static void InitialiseBoard()
    {
        for (int r = 0; r < 3; r++) // Iterate over rows
        {
            for (int c = 0; c < 3; c++) // Iterate over columns
            {
                board[r, c] = ' '; // Fill it board with empty spaces
            }
        }
    }

    static void PlayGame()
    {
        bool gameWon = false;
        // Loop through the game until a player wins or the game is a draw
        while (gameTurn < 9 && !gameWon)
        {
            DisplayBoard();
            PlayerMove();
            gameWon = CheckWin();
            gameTurn++;
        }
        DisplayBoard();

        if (gameWon)
        {
            Console.WriteLine("Congratulations! You are the winner of the WildTicTacToe game!");
        }
        else
        {
            Console.WriteLine("Oops. It's a draw!");
        }
    }

    static void DisplayBoard()
    {
        
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
    }

    static void PlayerMove()
    {
        int row, col;
        char piece;
        bool condition1, condition2, condition3, condition4;

        do
        {
            Console.Write("Enter row (0, 1, or 2): ");
            row = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter column (0, 1, or 2): ");
            col = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter piece (X or O): ");
            char.TryParse(Console.ReadLine()?.ToUpper(), out piece);

            condition1 = row < 0 || row > 2;
            condition2 = col < 0 || col > 2;
            condition3 = board[row, col] != ' ';
            condition4 = piece != 'X' && piece != 'O';

        } while (condition1 || condition2 || condition3 || condition4);

        board[row, col] = piece;
    }

// Check if the game meets the winning conditions
// in WildTicTacToe, the player wins if they have the same three pieces in a row, column, or diagonal
    static bool CheckWin()
    {
        return (CheckRows() || CheckColumns() || CheckDiagonals());
    }

    static bool CheckRows()
    {
        // It iterates over the rows and checks if: 
        for (int r = 0; r < 3; r++)
        {
            bool condition1 = board[r, 0] != ' '; // condition1 = the slot is not empty, and 
            bool condition2 = board[r, 0] == board[r, 1] && board[r, 1] == board[r, 2]; // condition2 = if the row has the same piece in all three columns
            if (condition1 && condition2)
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckColumns()
    {
        // It iterates over the columns and checks if:
        for (int c = 0; c < 3; c++)
        {
            bool condition1 = board[0, c] != ' '; // condition1 = the slot is not empty, and 
            bool condition2 = board[0, c] == board[1, c] && board[1, c] == board[2, c]; // condition2 = if the column has the same piece in all three rows
            if (condition1 && condition2)
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckDiagonals()
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
}