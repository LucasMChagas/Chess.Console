using System;
using chessboard;

namespace chess
{
    internal class ChessGame
    {
        public Chessboard Chessboard { get; private set;}
        private int Turn;
        private Color Player;
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
        private void PutPieces()
        {
            Chessboard.PutChessPiece(new Rook(Color.Black, Chessboard), new ChessPosition('c', 1).ToPositon());
            
        }
    }
}
