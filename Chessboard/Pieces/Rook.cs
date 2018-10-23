namespace Chessboard.Pieces
{
    public class Rook : Piece
    {
        public Rook(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            return p.Position.X == Position.X  || p.Position.Y == Position.Y;
        }
    }
}
