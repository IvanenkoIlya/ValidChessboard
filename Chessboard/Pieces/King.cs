using System.Collections.Generic;
using System.Linq;

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
                    (diff.Y >= -1 && diff.Y <= 1) &&
                    (p.Position != Position));
        }

        public override List<Piece> Attacks(List<Piece> pieces)
        {
            List<Piece> attacked = new List<Piece>();

            foreach(Piece p in pieces.Where(x => x.Black != Black))
            {
                if (Attacks(p))
                    attacked.Add(p);
            }

            return attacked;
        }

        public override string ToString()
        {
            return $"King at ({Position.X},{Position.Y})";
        }
    }
}
