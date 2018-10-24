using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessboard.Pieces
{
    public class Bishop : Piece
    {
        private List<Piece> blockedBy;

        public Bishop(int row, int col, char black) : base(row, col, black)
        {
            blockedBy = new List<Piece>();
        }

        public override bool Attacks(Piece p)
        {
            int distance = p.Position.X - Position.X;

            if (Math.Abs(distance) == Math.Abs(p.Position.Y - Position.Y))
            {
                if (p.Black == Black)
                    blockedBy.Add(p);
                else
                {
                    if (distance < 0)
                        return !blockedBy.Any(x => x.Position.X > p.Position.X && x.Position.X < Position.X);
                    else
                        return !blockedBy.Any(x => x.Position.X > Position.X && x.Position.X < p.Position.X);
                }
            }

            return false;
        }
    }
}
