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
    }
}
