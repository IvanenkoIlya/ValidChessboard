using System;

namespace Chessboard.Pieces
{
    public class Queen : Piece
    {
        public Queen(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            if (p.Position.X == Position.X ||
                p.Position.Y == Position.Y)
                return true;

            return Math.Abs(p.Position.X - Position.X) == Math.Abs(p.Position.Y - Position.Y);
        }
    }
}
