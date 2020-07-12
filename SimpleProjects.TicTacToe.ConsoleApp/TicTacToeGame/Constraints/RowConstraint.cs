using System.Collections.Generic;
using System.Linq;

namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame.Constraints
{
    public class RowConstraint : IBoardConstraint
    {
        private readonly List<BoardCell> _row;

        public RowConstraint(List<BoardCell> row)
        {
            _row = row;
        }

        public bool CheckConstraint()
        {
            return _row.All(x => x.Piece != null) && _row.All(x => x.Piece == _row[0].Piece);
        }

        public GamePiece? GetConstraintValue()
        {
            return _row[0].Piece;
        }
    }
}
