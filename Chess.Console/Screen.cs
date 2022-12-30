using System;
using chessboard;

namespace Chess
{
    internal class Screen
    { 
        public static void PrintChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Rows; i++)
            {
                
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(chessboard.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
