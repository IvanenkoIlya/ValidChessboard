using System;

namespace Chessboard.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            return Math.Abs(p.Position.X - Position.X) == Math.Abs(p.Position.Y - Position.Y);
        }
    }
}
