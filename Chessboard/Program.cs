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
                    string[] parts = line.Split(' ');
                    if (parts.Length != 3)
                    {
                        Console.WriteLine($"\tInvalid syntax: {{{line}}} should be three arguements");
                        Console.ReadLine();
                        return;
                    }

                    bool rowValid = int.TryParse(parts[1], out int row);
                    bool colValid = int.TryParse(parts[2], out int col);

                    if (!rowValid || !colValid)
                    {
                        Console.WriteLine($"\tError: Row or Column input is invalid: {line}");
                        if (row < 1 || row > 8)
                            Console.WriteLine($"\tError: Row ({row}) not in range 1-8");
                        if (col < 1 || col > 8)
                            Console.WriteLine($"\tError: Column ({col}) not in range 1-8");
                    }

                    switch (parts[0][0])
                    {
                        case 'K':
                        case 'k':
                            Pieces.Add(new King(row,int.Parse(parts[2]),parts[0][0]));
                            break;
                        case 'Q':
                        case 'q':
                            Pieces.Add(new Queen(row, int.Parse(parts[2]), parts[0][0]));
                            break;
                        case 'B':
                        case 'b':
                            Pieces.Add(new Bishop(row, int.Parse(parts[2]), parts[0][0]));
                            break;
                        case 'N':
                        case 'n':
                            Pieces.Add(new Knight(row, int.Parse(parts[2]), parts[0][0]));
                            break;
                        case 'R':
                        case 'r':
                            Pieces.Add(new Rook(row, int.Parse(parts[2]), parts[0][0]));
                            break;
                        default:
                            Console.WriteLine($"\tError: Piece {parts[0]} is unknown in line {line}");
                            Console.ReadLine();
                            return;
                    }

                }
            }
            else
            {
                File.Create(args[0]);
                Console.WriteLine("\tError: File not found. Created new file");
            }

            Console.ReadLine();
        }
    }    
}
