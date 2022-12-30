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
    }
}
