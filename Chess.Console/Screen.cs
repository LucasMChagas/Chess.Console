using System;
using chessboard;
using chess;
using System.Collections.Generic;

namespace Chess
{
    internal class Screen
    {
        public static void PrintGame(ChessGame game)
        {
            PrintChessboard(game.Chessboard);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turno: " + game.Turn);
            Console.WriteLine("Aguardando jogada: " + game.Player);
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Peças Capturadas");
            Console.Write("Brancas: ");
            PrintSet(game.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(game.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.WriteLine(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    PrintPiece(chessboard.Piece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintChessboard(Chessboard chessboard, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray; 

            for (int i = 0; i < chessboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if(possibleMoves[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(chessboard.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
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
                Console.Write(" ");

            }

        }
    }
}
