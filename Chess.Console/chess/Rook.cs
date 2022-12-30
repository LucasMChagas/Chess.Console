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
    }
}
