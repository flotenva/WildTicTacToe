namespace WildTicTacToe
{
    public class Menu
    {

        public static void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("## IFQ563 Object Oriented Design ##");
            Console.WriteLine("## Assignment 2: Implementation  ##");
            Console.WriteLine("###################################");
            Console.WriteLine("");
            Console.WriteLine("## Welcome to Wild Tic Tac Toe!  ##");
            Console.WriteLine("");
        }
        
        public static void DisplayMainOptions()
        {
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. See Instructions");
        }
        
        public static void DisplayInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine("Wild Tic-Tac-Toe Instructions:");
            Console.WriteLine("Like the classic Tic-Tac-Toe game, two players take turns placing an X or an O piece on a 3x3 board.");
            Console.WriteLine("However, in this game players can choose to place either X or O on each move.");
            Console.WriteLine("The first player who creates a line of three X's or O's in a row wins the game.");
            Console.WriteLine("");
        }
        
        public static void DisplayGameMode()
        {
            Console.WriteLine("Select game mode:");
            Console.WriteLine("1. Human vs Human");
            Console.WriteLine("2. Computer vs Human");
        }
        
        public static void DisplayGameOptions()
        {
            Console.WriteLine("1. Make a move");
            Console.WriteLine("2. Check Instructions");
            Console.WriteLine("3. Save game");
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine("5. Quit game");
        }
    }
}
