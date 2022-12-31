using chessboard;
using chess;
using System;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chessboard chessboard = new Chessboard(8, 8);

                chessboard.PutChessPiece(new Rook(Color.Black, chessboard), new Position(0, 0));
                chessboard.PutChessPiece(new Rook(Color.White, chessboard), new Position(0, 1));



                Screen.PrintChessboard(chessboard);

               
            }
            catch(ChessboardExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
