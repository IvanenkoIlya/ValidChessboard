using System;
using System.Collections.Generic;
using System.Linq;

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

        public override List<Piece> Attacks(List<Piece> pieces)
        {
            List<Piece> attacked = new List<Piece>();

            // all pieces of the opposite color
            foreach(Piece p in pieces.Where(x => x.Black != Black))
            {
                int xDiff = p.Position.X - Position.X;
                int yDiff = p.Position.Y - Position.Y;

                // if diagonal
                if( Math.Abs(xDiff) == Math.Abs(yDiff))
                {
                    bool blocked = false;

                    // all pieces of same color
                    foreach(Piece sameColor in pieces.Where(x => x.Position != p.Position))
                    {
                        int xSameDiff = sameColor.Position.X - Position.X;
                        int ySameDiff = sameColor.Position.Y - Position.Y;

                        // if diagonal
                        if(Math.Abs(xSameDiff) == Math.Abs(ySameDiff))
                        {
                            // check if on same diagonal as outer piece
                            if((xDiff > 0 && xSameDiff > 0 && yDiff > 0 && ySameDiff > 0 && xDiff > xSameDiff) ||
                            (xDiff > 0 && xSameDiff > 0 && yDiff < 0 && ySameDiff < 0 && xDiff > xSameDiff) ||
                            (xDiff < 0 && xSameDiff < 0 && yDiff > 0 && ySameDiff > 0 && xDiff < xSameDiff) ||
                            (xDiff < 0 && xSameDiff < 0 && yDiff < 0 && ySameDiff < 0 && xDiff < xSameDiff))
                            {
                                blocked = true;
                                break;
                            }
                        }
                    }

                    if (!blocked)
                        attacked.Add(p);
                }
            }

            return attacked;
        }

        public override string ToString()
        {
            return $"Bishop at ({Position.X},{Position.Y})";
        }
    }
}
