namespace WildTicTacToe
{
    public class Game
    {
        public static void RunGame(Board board, Player player1, Player player2, int gameTurn)
        {

            bool gameWon = false;

            //// PLAY GAME ////
            while (gameTurn < 9 && !gameWon)
            {
                // Alternate between player 1 and player 2
                if (gameTurn % 2 == 0) // When gameTurn is an even number, player1 makes a move
                {
                    PlayerTurn(player1, board, player1, player2, gameTurn, "Player 1");
                }
                else // When gameTurn is an odd number, it is player2 turn
                {
                    PlayerTurn(player2, board, player1, player2, gameTurn, "Player 2");
                }
                gameWon = board.CheckWin();
                gameTurn++;
            }


            //// GAME ENDS ////
            board.DisplayBoard();
            string gameResult = gameWon ? $"Congratulations! {(gameTurn % 2 != 0 ? "Player 1" : "Player 2")} is the winner of the WildTicTacToe game!" : "Oops. It's a draw!";
            Console.WriteLine($"\n{gameResult}"); // Display the winner of the game

            CountDownMessage("Returning to Main Menu in");

            Program.Main(null);

            // METHODS //

            static void PlayerTurn(Player player, Board board, Player player1, Player player2, int gameTurn, string playerName)
            {
                if (player.GetType().Name == nameof(ComputerPlayer))
                    player.MakeMove(board);
                else
                {
                    string? option;
                    do
                    {
                        board.DisplayBoard();
                        Console.WriteLine($"{playerName}'s turn: enter MOVE to make a move, or enter OPTIONS to view game options.");
                        option = Console.ReadLine()?.ToUpper();
                        switch (option)
                        {
                            case "MOVE":
                                player.MakeMove(board);
                                break;
                            case "OPTIONS":
                                int optionNo = 0;
                                do
                                {
                                    board.DisplayBoard();
                                    Menu.DisplayGameOptions();
                                    int.TryParse(Console.ReadLine(), out optionNo);
                                    switch (optionNo)
                                    {
                                        case 1:
                                            // 1. Return to game
                                            break;
                                        case 2:
                                            // 2. Display instructions
                                            Menu.DisplayInstructions();
                                            Console.WriteLine("Press Any Key to Continue...");
                                            Console.ReadKey();
                                            break;
                                        case 3:
                                            // 3. Save game
                                            SaveGame(board, player1, player2, gameTurn);
                                            Console.WriteLine("Press Any Key to Continue...");
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            // 4. Quit game and return to main menu
                                            Program.Main(null);
                                            break;
                                        default:
                                            CountDownMessage("Invalid option. Try again in", 3);
                                            break;
                                    }
                                } while (optionNo != 1);
                                break;

                            default:
                                CountDownMessage("Invalid option. Try again in", 3);
                                break;
                        }
                    } while (option != "MOVE");
                }
            }

            static void SaveGame(Board board, Player player1, Player player2, int gameTurn)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "savedGame.txt");
                using var fs = new FileStream(filePath, FileMode.Create);
                using var writer = new StreamWriter(fs);
                {
                    // Save the board state
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            writer.Write(board.GetPiece(r, c));
                        }
                        writer.WriteLine();
                    }

                    // Save the game turn
                    writer.WriteLine(gameTurn);

                    // Save player types
                    writer.WriteLine(player1.GetType().Name);
                    writer.WriteLine(player2.GetType().Name);
                }
                board.DisplayBoard();
                Console.WriteLine($"Game saved successfully at {filePath}\n");
            }

            static void CountDownMessage (string text, int seconds = 5)
            {
                for (int i = seconds; i > 0; i--)
                {
                    Console.Write($"{text} {i}...");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }

        }

        // PUBLIC METHODS //
        public static void InitialiseNewGame()
        {
            Board board = new Board();
            Player player1 = null;
            Player player2 = null;
            int gameTurn = 0;
            int gameMode;

            Menu.DisplayWelcome();
            Menu.DisplayGameMode();

            do
            {
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
                        Menu.DisplayWelcome();
                        Menu.DisplayGameMode();
                        Console.WriteLine("\nInvalid mode selected. Please try again.");
                        break;
                }
            } while (gameMode != 1 && gameMode != 2);

            RunGame(board, player1, player2, gameTurn);
        }

        public static void LoadGame()
        {
            Board board = new Board();
            Player player1 = null;
            Player player2 = null;
            int gameTurn = 0;

            using (FileStream fs = new FileStream("savedGame.txt", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                // Load the board state
                for (int r = 0; r < 3; r++)
                {
                    string line = reader.ReadLine();
                    for (int c = 0; c < 3; c++)
                    {
                        board.SetPiece(r, c, line[c]);
                    }
                }

                // Load the game turn
                gameTurn = int.Parse(reader.ReadLine());

                // Load player types and create players
                player1 = CreatePlayer(reader.ReadLine());
                player2 = CreatePlayer(reader.ReadLine());
            }

            static Player CreatePlayer(string playerType)
            {
                return playerType == nameof(HumanPlayer) ? new HumanPlayer() : new ComputerPlayer();
            }

            RunGame(board, player1, player2, gameTurn);
        }
    }
}
