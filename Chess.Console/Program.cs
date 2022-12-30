using chessboard;
using System;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position board = new Position(3, 4);

            Console.WriteLine("Position: " + board);
            Console.ReadKey();
        }
    }
}
