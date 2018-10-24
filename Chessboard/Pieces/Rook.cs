using System.Collections.Generic;
using System.Linq;

namespace Chessboard.Pieces
{
    public class Rook : Piece
    {
        private List<Piece> blockedBy;

        public Rook(int row, int col, char black) : base(row, col, black)
        {
            blockedBy = new List<Piece>();
        }

        public override bool Attacks(Piece p)
        {
            int xDiff = p.Position.X - Position.X;
            int yDiff = p.Position.Y - Position.Y;

            if ( xDiff == 0 || yDiff == 0)
            {
                if (p.Black == Black)
                    blockedBy.Add(p);
                else
                {
                    if(xDiff == 0)
                    {
                        if (yDiff < 0)
                            return !blockedBy.Any(x => x.Position.Y > p.Position.Y && x.Position.Y < Position.Y);
                        else
                            return !blockedBy.Any(x => x.Position.Y > Position.Y && x.Position.Y < p.Position.Y);
                    }
                    else
                    {
                        if (xDiff < 0)
                            return !blockedBy.Any(x => x.Position.X > p.Position.X && x.Position.X < Position.X);
                        else
                            return !blockedBy.Any(x => x.Position.X > Position.X && x.Position.X < p.Position.X);
                    }
                }
            }

            return false;
        }
    }
}
