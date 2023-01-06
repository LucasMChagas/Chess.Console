namespace chessboard
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMovements { get; protected set; }
        public Chessboard Board { get; protected set; }

        public Piece(Color color, Chessboard board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMovements = 0;
        }

        public abstract bool[,] PossibleMoves();
        

        public void IncrementMovements()
        {
            NumberOfMovements++;
        }
        public bool ThereArePossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Rows ; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.Row, pos.Column];
        }


    }
}
