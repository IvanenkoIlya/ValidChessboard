namespace Chessboard.Pieces
{
    public class King : Piece
    {
        public King(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            Point diff = p.Position - Position;

            return ((diff.X >= -1 && diff.X <= 1) &&
                    (diff.Y >= -1 && diff.Y <= 1));
        }
    }
}
