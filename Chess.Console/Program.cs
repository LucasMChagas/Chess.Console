using chessboard;
using System;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard(8, 8);
            
            Screen.PrintChessboard(chessboard);

            Console.ReadKey();
        }
    }
}
