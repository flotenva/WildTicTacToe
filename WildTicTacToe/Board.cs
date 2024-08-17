namespace WildTicTacToe
{
    public abstract class Board
    {
        public abstract void InitialiseBoard();
        public abstract bool IsValidMove(int row, int col, char piece);
        public abstract void MakeMove(int row, int col, char piece);
        public abstract bool CheckWin();
        public abstract void DisplayBoard();
        public abstract char GetPiece(int row, int col);
        public abstract void SetPiece(int row, int col, char piece);

    }
}
