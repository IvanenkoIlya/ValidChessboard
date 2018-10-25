using System.Collections.Generic;

namespace Chessboard.Pieces
{
    public abstract class Piece
    {
        public Point Position;
        public bool Black;

        public Piece( int col, int row, char black)
        {
            Position = new Point(col, row);
            Black = !char.IsUpper(black);
        }

        public abstract bool Attacks(Piece p);
        public abstract List<Piece> Attacks(List<Piece> pieces);
    }
}
