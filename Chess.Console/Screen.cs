using System;
using chessboard;
using chess;

namespace Chess
{
    internal class Screen
    { 
        public static void PrintChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(chessboard.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            
        }

        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s.Substring(1));
            return new ChessPosition(column, row);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White )
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
