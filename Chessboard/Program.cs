using Chessboard.Pieces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chessboard
{
    class Program
    {
        static List<Piece> Pieces;

        static void Main(string[] args)
        {
            Pieces = new List<Piece>();

            if (args.Count() < 1)
            {
                Console.WriteLine("\tError: No argument entered");
                Console.WriteLine("\t\tFirst argument should be input file");
                Console.ReadLine();
                return;
            }

            if (File.Exists(args[0]))
            {
                using (StreamReader sr = File.OpenText(args[0]))
                {
                    string line = sr.ReadLine();

                    while (line != null)
                    {

                        string[] parts = line.Split(' ');
                        if (parts.Length != 3)
                        {
                            Console.WriteLine($"\tInvalid syntax: {{{line}}} should be three arguments");
                            Console.ReadLine();
                            return;
                        }

                        if (parts[0].StartsWith("--"))
                        {
                            line = sr.ReadLine();
                            continue;
                        }

                        bool rowValid = int.TryParse(parts[1], out int col);
                        bool colValid = int.TryParse(parts[2], out int row);

                        if (!rowValid || !colValid)
                        {
                            Console.WriteLine($"\tError: Row or Column input is invalid: {line}");
                            if (col < 1 || col > 8)
                                Console.WriteLine($"\tError: Row ({col}) not in range 1-8");
                            if (row < 1 || row > 8)
                                Console.WriteLine($"\tError: Column ({row}) not in range 1-8");
                        }

                        Piece piece;

                        switch (parts[0][0])
                        {
                            case 'K':
                            case 'k':
                                piece = new King(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            case 'Q':
                            case 'q':
                                piece = new Queen(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            case 'B':
                            case 'b':
                                piece = new Bishop(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            case 'N':
                            case 'n':
                                piece = new Knight(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            case 'R':
                            case 'r':
                                piece = new Rook(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            case 'P':
                            case 'p':
                                piece = new Pawn(col, int.Parse(parts[2]), parts[0][0]);
                                break;
                            default:
                                Console.WriteLine($"\tError: Piece {parts[0]} is unknown in line {line}");
                                Console.ReadLine();
                                return;
                        }

                        //foreach(Piece p in Pieces)
                        //{
                        //    if(p.Attacks(piece))
                        //    {
                        //        Console.WriteLine($"Invalid configuration: {p.GetType().Name} at ({p.Position.X},{p.Position.Y}) attacks {piece.GetType().Name} at ({piece.Position.X},{piece.Position.Y})");
                        //        PrintBoard();
                        //        Console.ReadLine();
                        //        return;
                        //    }

                        //    if (piece.Attacks(p))
                        //    {
                        //        Console.WriteLine($"Invalid configuration: {piece.GetType().Name} at ({piece.Position.X},{piece.Position.Y}) attacks {p.GetType().Name} at ({p.Position.X},{p.Position.Y})");
                        //        PrintBoard();
                        //        Console.ReadLine();
                        //        return;
                        //    }
                        //}

                        Pieces.Add(piece);
                        line = sr.ReadLine();
                    }

                    foreach(Piece p in Pieces)
                    {
                        foreach(Piece attacked in p.Attacks(Pieces))
                        {
                            Console.WriteLine($"{p} attacks {attacked}");
                        }
                    }

                    PrintBoard();

                    Console.ReadLine();
                }
            }
        }

        private static void PrintBoard()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    bool whiteTile;

                    if (i % 2 == 0)
                    {
                        whiteTile = j % 2 == 0;
                        Console.BackgroundColor = whiteTile ? ConsoleColor.DarkGray : ConsoleColor.Black;
                    }
                    else
                    {
                        whiteTile = j % 2 != 0;
                        Console.BackgroundColor = whiteTile ? ConsoleColor.DarkGray : ConsoleColor.Black;
                    }

                    Piece p = Pieces.FirstOrDefault(x => x.Position == new Point(j, i));
                    if(p != null)
                    {
                        char color = p.Black ? 'B' : 'W';
                        char piece = p.GetType().Name == "Knight" ? 'N' : p.GetType().Name[0];
                        Console.ForegroundColor = p.Black ? (whiteTile ? ConsoleColor.Black : ConsoleColor.DarkGray) : ConsoleColor.White;
                        Console.Write($"{color}{piece}");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    
                }
                
                Console.WriteLine();
            }
        }
    }
}
