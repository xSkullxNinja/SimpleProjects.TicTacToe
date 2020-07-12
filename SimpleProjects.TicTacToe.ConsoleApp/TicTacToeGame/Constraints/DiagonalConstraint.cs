using System.Collections.Generic;
using System.Linq;

namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame.Constraints
{
    public class DiagonalConstraint : IBoardConstraint
    {
        private readonly List<BoardCell> _diagonal;

        public DiagonalConstraint(List<BoardCell> diagonal)
        {
            _diagonal = diagonal;
        }

        public bool CheckConstraint()
        {
            return _diagonal.All(x => x.Piece != null) && _diagonal.All(x => x.Piece == _diagonal[0].Piece);
        }

        public GamePiece? GetConstraintValue()
        {
            return _diagonal[0].Piece;
        }
    }
}
