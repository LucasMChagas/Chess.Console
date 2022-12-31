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
                ChessGame game = new ChessGame();

                while(game.Finished == false)
                {
                    Console.Clear();
                    Screen.PrintChessboard(game.Chessboard);

                    Console.Write("Digite a posição de origem");
                    Position home = Screen.ReadPosition().ToPositon();
                    Console.Write("Digite a posição de origem");
                    Position destination = Screen.ReadPosition().ToPositon();

                    game.ExecuteMovement(home, destination);

                }
            }
            catch(ChessboardExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
