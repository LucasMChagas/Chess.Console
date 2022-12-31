namespace chessboard
{
    internal class Chessboard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Chessboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }        

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Row, pos.Column];
        }

        public bool ThereIsAPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PutChessPiece(Piece p, Position pos)
        {
            if (ThereIsAPiece(pos))
            {
                throw new ChessboardExeption("There is already a chess piece in this position!");
            }
            Pieces[pos.Row,pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Row <0 || pos.Row >=Rows || pos.Column <0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new ChessboardExeption("Invalid Position!");
            }
        }
    }
}
