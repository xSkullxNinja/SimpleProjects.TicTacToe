using System;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class BoardPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public BoardPosition()
        {
        }

        public BoardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            return obj != null && typeof(BoardPosition) == obj.GetType() && Equals((BoardPosition)obj);
        }

        private bool Equals(BoardPosition other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
