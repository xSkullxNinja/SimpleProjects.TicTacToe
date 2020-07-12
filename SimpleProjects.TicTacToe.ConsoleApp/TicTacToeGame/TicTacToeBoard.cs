using System;
using System.Collections.Generic;
using System.Linq;

using SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame.Constraints;

namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame
{
    public class TicTacToeBoard : IGameBoard
    {
        private Random rand = new Random();
        private readonly List<BoardCell> _boardCells = new List<BoardCell>();

        private readonly List<IBoardConstraint> _boardConstraints = new List<IBoardConstraint>();
        
        public void SetupConstraints()
        {
            _boardConstraints.Add(new RowConstraint(GetRow(0)));
            _boardConstraints.Add(new RowConstraint(GetRow(1)));
            _boardConstraints.Add(new RowConstraint(GetRow(2)));
            _boardConstraints.Add(new ColumnConstraint(GetColumn(0)));
            _boardConstraints.Add(new ColumnConstraint(GetColumn(1)));
            _boardConstraints.Add(new ColumnConstraint(GetColumn(2)));
            _boardConstraints.Add(new DiagonalConstraint(GetDiagonal(x => x.Row == x.Column)));
            _boardConstraints.Add(new DiagonalConstraint(GetDiagonal(x => x.Row + x.Column == 2
            )));
        }

        public bool HasWinner()
        {
            return _boardConstraints.Any(x => x.CheckConstraint());
        }

        public bool IsCatGame()
        {
            return _boardCells.All(x => x.Piece != null);
        }

        public void PrintBoard()
        {
            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    var piece = _boardCells.SingleOrDefault(x => x.Row == row && x.Column == column)?.Piece;
                    Console.Write(piece == null ? " " : $"{piece}");
                    Console.Write("|");
                }
                Console.WriteLine("");
                Console.WriteLine("-+-+-");
            }
            Console.WriteLine("");
        }

        public GamePiece? GetWinner()
        {
            return _boardConstraints.First(x => x.CheckConstraint()).GetConstraintValue();
        }

        public void PlayRandom(GamePiece player)
        {
            BoardCell selectedCell;
            do
            {
                var value = rand.Next(0, 9);
                selectedCell = _boardCells.Single(x => x.Row == value / 3 && x.Column == value % 3);
            } while (selectedCell.Piece != null);

            selectedCell.Piece = player;
        }

        public void SetupBoard()
        {
            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    _boardCells.Add(new BoardCell {Row = row, Column = column});
                }
            }
        }

        public void ClearBoard()
        {
            foreach (var cell in _boardCells)
            {
                cell.Piece = null;
            }
        }

        private List<BoardCell> GetRow(int row)
        {
            return new List<BoardCell>(_boardCells.Where(x => x.Row == row).ToList());
        }

        private List<BoardCell> GetColumn(int column)
        {
            return new List<BoardCell>(_boardCells.Where(x => x.Column == column).ToList());
        }

        private List<BoardCell> GetDiagonal(Func<BoardCell, bool> diagonalFunc)
        {
            return new List<BoardCell>(_boardCells.Where(diagonalFunc).ToList());
        }
    }
}
