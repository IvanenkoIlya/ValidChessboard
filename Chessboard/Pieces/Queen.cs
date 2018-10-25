using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessboard.Pieces
{
    public class Queen : Piece
    {
        public Queen(int row, int col, char black) : base(row, col, black) { }

        public override bool Attacks(Piece p)
        {
            if (p.Black == Black)
                return false;

            if (p.Position.X == Position.X ||
                p.Position.Y == Position.Y)
                return true;

            return Math.Abs(p.Position.X - Position.X) == Math.Abs(p.Position.Y - Position.Y);
        }

        public override List<Piece> Attacks(List<Piece> pieces)
        {
            List<Piece> attacked = new List<Piece>();

            foreach(Piece p in pieces.Where(x => x.Black != Black))
            {
                bool blocked = false;
                int xDiff = p.Position.X - Position.X;
                int yDiff = p.Position.Y - Position.Y;
                Direction d = RelativeDirection(p);

                if(d != Direction.None)
                {
                    foreach (Piece sameColor in pieces.Where(x => x.Black == Black))
                    {
                        if (d == RelativeDirection(sameColor))
                        {
                            int xSameDiff = sameColor.Position.X - Position.X;
                            int ySameDiff = sameColor.Position.Y - Position.Y;

                            switch (d)
                            {
                                case Direction.Top:
                                    if (yDiff < ySameDiff)
                                        blocked = true;
                                    break;
                                case Direction.TopRight:
                                case Direction.Right:
                                case Direction.BottomRight:
                                    if (xDiff > xSameDiff)
                                        blocked = true;
                                    break;
                                case Direction.Bottom:
                                    if (yDiff > ySameDiff)
                                        blocked = true;
                                    break;
                                case Direction.BottomLeft:
                                case Direction.Left:
                                case Direction.TopLeft:
                                    if (xDiff < xSameDiff)
                                        blocked = true;
                                    break;
                                case Direction.None:
                                default:
                                    break;
                            }

                            if (blocked)
                                break;
                        }
                    }

                    if (!blocked)
                        attacked.Add(p);
                }
            }

            return attacked;
        }

        private Direction RelativeDirection(Piece p)
        {
            int colDiff = p.Position.X - Position.X; // + if right, - if left
            int rowDiff = p.Position.Y - Position.Y; // + if bellow, - if above  

            if (colDiff == 0 && rowDiff != 0) // Same column, different row
                return rowDiff < 0 ? Direction.Top : Direction.Bottom;
            else if (colDiff != 0 && rowDiff == 0) // Same row, different column
                return colDiff > 0 ? Direction.Right : Direction.Left;
            else if (colDiff > 0 && Math.Abs(rowDiff) == Math.Abs(colDiff))
                return rowDiff < 0 ? Direction.TopRight : Direction.BottomRight;
            else if (colDiff < 0 && Math.Abs(rowDiff) == Math.Abs(colDiff))
                return rowDiff < 0 ? Direction.TopLeft : Direction.BottomLeft;

            return Direction.None;
        }

        public override string ToString()
        {
            return $"Queen at ({Position.X},{Position.Y})";
        }

        private enum Direction
        {
            Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left, TopLeft, None
        }
    }
}
