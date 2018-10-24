namespace Chessboard.Pieces
{
    public abstract class Piece
    {
        public Point Position;
        public bool Black;

        public Piece(int row, int col, char black)
        {
            Position = new Point(row, col);
            Black = !char.IsUpper(black);
        }

        public abstract bool Attacks(Piece p);
    }
}
