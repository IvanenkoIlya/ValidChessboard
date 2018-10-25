using System.Collections.Generic;
using System.Linq;

namespace Chessboard.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            if(Black)
            {
                return p.Position == Position - new Point(-1, 1) || p.Position == Position - new Point(-1, -1);
            }
            else
            {
                return p.Position == Position - new Point(1, 1) || p.Position == Position - new Point(1, -1);
            }
        }

        public override List<Piece> Attacks(List<Piece> pieces)
        {
            List<Piece> attacked = new List<Piece>();

            foreach (Piece p in pieces.Where(x => x.Black != Black))
            {
                if (Attacks(p))
                    attacked.Add(p);
            }

            return attacked;
        }

        public override string ToString()
        {
            return $"Pawn at ({Position.X},{Position.Y})";
        }
    }
}
