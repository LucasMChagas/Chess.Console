using System;
using System.Collections.Generic;
using chessboard;

namespace chess
{
    internal class ChessGame
    {
        public Chessboard Chessboard { get; private set;}
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessGame()
        {
            Chessboard = new Chessboard(8,8);
            Turn = 1;
            Player = Color.White;
            Finished = false;
            Check = false;
            Captured = new HashSet<Piece>();
            Pieces = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMovement(Position home, Position destination)
        {
            Piece p = Chessboard.RemoveChessPiece(home);
            p.IncrementMovements();
            Piece CapturedPiece = Chessboard.RemoveChessPiece(destination);
            Chessboard.PutChessPiece(p, destination);
            if(CapturedPiece != null)
            {
                Captured.Add(CapturedPiece);
            }
            return CapturedPiece;
        }
        public void UndoMove(Position home, Position destination, Piece capturedPiece)
        {
            Piece p = Chessboard.RemoveChessPiece(destination);
            p.decrementMovements();
            if(capturedPiece != null)
            {
                Chessboard.PutChessPiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }
            Chessboard.PutChessPiece(p, home);
        }
        public void PerformMove( Position home, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(home, destination);
            if (TheKingIsInCheck(Player))
            {
                UndoMove(home, destination, capturedPiece);
                throw new ChessboardExeption("Você não pode se colocar em xeque!");
            }
            if (TheKingIsInCheck(Oponnent(Player)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

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
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }                
            }
            return aux;
        }
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }                
            }
            return null;
        }
        public bool TheKingIsInCheck(Color color)
        {
            Piece R = King(color);
            if (R == null)
            {
                throw new ChessboardExeption("Não há um rei no tabuleiro!");

            }
            foreach(Piece x in PiecesInGame(Oponnent(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[R.Position.Row, R.Position.Column])
                {
                    return true;
                }                
            }
            return false;
        }
        private Color Oponnent(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        public void PutNewPiece(char column, int row, Piece piece)
        {
            Chessboard.PutChessPiece(piece, new ChessPosition(column, row).ToPositon());
            Pieces.Add(piece);
        }
        private void PutPieces()
        {
            PutNewPiece('a', 1, new Rook(Color.White, Chessboard));
            
        }
    }
}
