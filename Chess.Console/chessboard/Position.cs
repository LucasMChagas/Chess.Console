using System.Text;

namespace chessboard
{
    internal class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }        

        public void SetValues(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(Row);
            toString.Append(", ");
            toString.Append(Column);
            return toString.ToString();
        }
    }
}
