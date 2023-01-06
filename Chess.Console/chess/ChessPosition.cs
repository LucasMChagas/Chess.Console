using System;
using chessboard;

namespace chess
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        /// <summary> 
        /// Converte a classe ChessPosition (modelo usado no xadrez) para a classe Position para ser compativel
        /// com acesso em arrays utilizada no código ex: h1 h - a (7 - 0) = 7 | 8 - 1 = 7  acessada array [ 7 , 7 ].
        /// </summary>

        public Position ToPositon()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
