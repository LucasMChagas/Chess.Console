using System.Text;
using System;

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
