namespace chessboard
{
    internal class Piece
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

        public void IncrementMovements()
        {
            NumberOfMovements++;
        }


    }
}
