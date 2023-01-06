using System;
using chessboard;

namespace chess
{
    internal class ChessGame
    {
        public Chessboard Chessboard { get; private set;}
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Chessboard = new Chessboard(8,8);
            Turn = 1;
            Player = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMovement(Position home, Position destination)
        {
            Piece p = Chessboard.RemoveChessPiece(home);
            p.IncrementMovements();
            Piece CapturedPiece = Chessboard.RemoveChessPiece(destination);
            Chessboard.PutChessPiece(p, destination);
        }
        public void PerformMove( Position home, Position destination)
        {
            ExecuteMovement(home, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidHomePosition(Position pos)
        {
            if (Chessboard.Piece(pos) == null)
            {
                throw new ChessboardExeption("Não existe peça na posição de origem escolhida!");
            }
            if (Player != Chessboard.Piece(pos).Color)
            {
                throw new ChessboardExeption("A peça de origem escolhida não é sua!");
            }
            if (!Chessboard.Piece(pos).ThereArePossibleMoves())
            {
                throw new ChessboardExeption("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void ValidDestinationPosition(Position home, Position destination)
        {
            if (!Chessboard.Piece(home).CanMoveTo(destination))
            {
                throw new ChessboardExeption("Posição de destino inválida!");
            }
        }

        private void ChangePlayer()
        {
            if(Player == Color.White)
            {
                Player = Color.Black;
            }
            else
            {
                Player = Color.White;
            }
        }
        private void PutPieces()
        {
            Chessboard.PutChessPiece(new Rook(Color.Black, Chessboard), new ChessPosition('h', 1).ToPositon());
            
        }
    }
}
