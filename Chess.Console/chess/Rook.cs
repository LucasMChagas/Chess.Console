using chessboard;

namespace chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Chessboard board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //up
            position.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row = position.Row - 1;
            }
            //down
            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row = position.Row + 1;
            }
            //right
            position.SetValues(Position.Row , Position.Column +1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            position.SetValues(Position.Row , Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }
            return mat;
        }
    }
}
