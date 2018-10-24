using System;
using System.Collections.Generic;

namespace Chessboard.Pieces
{
    public class Queen : Piece
    {
        private List<Piece> blockedBy;

        public Queen(int row, int col, char black) : base(row, col, black)
        {
            blockedBy = new List<Piece>();
        }

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
