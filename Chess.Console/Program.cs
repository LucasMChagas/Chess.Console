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
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessboard(game.Chessboard);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + game.Turn);
                        Console.WriteLine("Aguardando jogada: " + game.Player);

                        Console.Write("Digite a posição de origem");
                        Position home = Screen.ReadPosition().ToPositon();
                        game.ValidHomePosition(home);

                        bool[,] possiblePositions = game.Chessboard.Piece(home).PossibleMoves();

                        Console.Clear();
                        Screen.PrintChessboard(game.Chessboard, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Digite a posição de destino");
                        Position destination = Screen.ReadPosition().ToPositon();
                        game.ValidDestinationPosition(home, destination);

                        game.PerformMove(home, destination);
                    }
                    catch(ChessboardExeption ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    

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
