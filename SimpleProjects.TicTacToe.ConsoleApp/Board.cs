using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class Board : IPlayerBoard
    {
        private readonly List<BoardCell> _gameBoard;

        public Board()
        {
            _gameBoard = new List<BoardCell>();
            GenerateGameBoard();
        }

        public void StartNewGame()
        {
            ClearGameBoard();
        }

        private void ClearGameBoard()
        {
            foreach (var cell in _gameBoard)
            {
                cell.Mark = BoardMark.Empty;
            }
        }

        public void PrintBoard()
        {
            for (var i = 1; i <= 3; i++)
            {
                for (var j = 1; j <= 3; j++)
                {
                    var mark = _gameBoard.Single(x => x.Position.Row == i && x.Position.Column == j).Mark;
                    var output = mark == BoardMark.Empty ? " " : mark.ToString();
                    if (j == 3)
                    {
                        Console.WriteLine($"{output}");
                        break;
                    }
                    Console.Write($"{output}");
                    Console.Write("|");
                }
                if (i != 3)
                {
                    Console.WriteLine("-+-+-");
                }
            }
            Console.WriteLine("");
        }

        private void GenerateGameBoard()
        {
            for (var i = 0; i < 9; i++)
            {
                var boardCell = new BoardCell
                {
                    Position = new BoardPosition
                    {
                        Row = i / 3 + 1,
                        Column = i % 3 + 1
                    },
                    Mark = BoardMark.Empty
                };
                _gameBoard.Add(boardCell);
            }
        }

        public bool CanSelectCell(BoardPosition playerSelection)
        {
            return _gameBoard.Single(x => x.Position.Equals(playerSelection)).Mark == BoardMark.Empty;
        }

        public BoardCell SelectCell(BoardPosition playerSelection)
        {
            return _gameBoard.Single(x => x.Position.Equals(playerSelection));
        }

        public void MarkMove(BoardMark playerPiece, BoardPosition playerMove)
        {
            _gameBoard.Single(x => x.Position.Equals(playerMove)).Mark = playerPiece;
        }

        public bool IsFull()
        {
            return _gameBoard.All(x => x.Mark != BoardMark.Empty);
        }

        public bool HasWinner()
        {
            return RowWin() || ColumnWin() || DiagonalWin();
        }

        private bool RowWin()
        {
            return AllSame(_gameBoard.Where(x => x.Position.Row == 1).Select(x => x.Mark)) ||
                   AllSame(_gameBoard.Where(x => x.Position.Row == 2).Select(x => x.Mark)) ||
                   AllSame(_gameBoard.Where(x => x.Position.Row == 3).Select(x => x.Mark));
        }

        private bool ColumnWin()
        {
            return AllSame(_gameBoard.Where(x => x.Position.Column == 1).Select(x => x.Mark)) ||
                   AllSame(_gameBoard.Where(x => x.Position.Column == 2).Select(x => x.Mark)) ||
                   AllSame(_gameBoard.Where(x => x.Position.Column == 3).Select(x => x.Mark));
        }

        private bool DiagonalWin()
        {
            return AllSame(_gameBoard.Where(x => x.Position.Row == x.Position.Column).Select(x => x.Mark)) ||
                   AllSame(_gameBoard.Where(x => x.Position.Row == 4 - x.Position.Column).Select(x => x.Mark));
        }

        private bool AllSame(IEnumerable<BoardMark> marks)
        {
            var boardMarks = marks.ToList();
            return boardMarks.All(x => x == boardMarks.First() && x != BoardMark.Empty);
        }
    }
}
