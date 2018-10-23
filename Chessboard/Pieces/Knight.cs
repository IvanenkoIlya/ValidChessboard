namespace Chessboard.Pieces
{
    public class Knight : Piece
    {
        public Knight(int row, int col, char black) : base(row, col, black) { }

        private Point[] offsets = 
        {
            new Point(1,2),
            new Point(2,1),
            new Point(2,-1),
            new Point(1,-2),
            new Point(-1,-2),
            new Point(-2,-1),
            new Point(-2,1),
            new Point(-1,2)
        };

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            foreach (Point pt in offsets)
            {
                if (p.Position == (Position + pt))
                    return true;
            }

            return false;
        }
    }
}
