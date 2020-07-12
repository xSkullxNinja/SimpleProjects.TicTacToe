using System.Collections.Generic;
using System.Linq;

namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame.Constraints
{
    public class ColumnConstraint : IBoardConstraint
    {
        private readonly List<BoardCell> _column;

        public ColumnConstraint(List<BoardCell> column)
        {
            _column = column;
        }

        public bool CheckConstraint()
        {
            return _column.All(x => x.Piece != null) && _column.All(x => x.Piece == _column[0].Piece);
        }

        public GamePiece? GetConstraintValue()
        {
            return _column[0].Piece;
        }
    }
}
