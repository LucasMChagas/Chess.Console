using chessboard;

namespace chess
{
    internal class King : Piece
    {
        public King(Color color, Chessboard board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows,Board.Columns];

            Position position = new Position(0, 0);

            //up
            position.SetValues(Position.Row - 1 , Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //ne
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            //right
            position.SetValues(Position.Row , Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //se
            position.SetValues(Position.Row + 1, Position.Column + 1 );
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //down
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //so
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //left
            position.SetValues(Position.Row , Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //no
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            return mat;
        }
    }
}
