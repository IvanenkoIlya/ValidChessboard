using System.Collections.Generic;
using System.Linq;

namespace Chessboard.Pieces
{
    public class Rook : Piece
    {
        public Rook(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            return (p.Position.X == Position.X) || (p.Position.Y == Position.Y);
        }

        public override List<Piece> Attacks(List<Piece> pieces)
        {
            List<Piece> attacked = new List<Piece>();

            // different color pieces
            foreach (Piece p in pieces.Where(x => x.Black != Black))
            {
                int xDiff = p.Position.X - Position.X;
                int yDiff = p.Position.Y - Position.Y;

                if ((xDiff == 0 || yDiff == 0) && xDiff != yDiff)
                {
                    bool blocked = false;

                    foreach( Piece sameColor in pieces.Where(x => x.Position != p.Position))
                    {
                        int xSameDiff = sameColor.Position.X - Position.X;
                        int ySameDiff = sameColor.Position.Y - Position.Y;

                        if(xSameDiff == 0 && ySameDiff == 0)
                        {
                            if (xDiff == 0 && xSameDiff == 0)
                            {
                                if ((yDiff > 0 && ySameDiff > 0 && yDiff > ySameDiff) ||
                                   (yDiff < 0 && ySameDiff < 0 && yDiff < ySameDiff))
                                {
                                    blocked = true;
                                    break;
                                }
                            }
                            else if (yDiff == 0 && ySameDiff == 0)
                            {
                                if ((xDiff > 0 && xSameDiff > 0 && xDiff > xSameDiff) ||
                                   (xDiff < 0 && xSameDiff < 0 && xDiff < xSameDiff))
                                {
                                    blocked = true;
                                    break;
                                }
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
            return $"Rook at ({Position.Y},{Position.X})";
        }
    }
}
