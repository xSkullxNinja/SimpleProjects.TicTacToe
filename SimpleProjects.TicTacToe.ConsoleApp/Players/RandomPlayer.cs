using System;

namespace SimpleProjects.TicTacToe.ConsoleApp.Players
{
    public class RandomPlayer : IPlayer
    {
        private readonly Random _random;
        public BoardMark GamePiece { get; set; }

        public RandomPlayer(BoardMark playerMark)
        {
            _random = new Random();
            GamePiece = playerMark;
        }

        public BoardPosition DetermineMove(IPlayerBoard gameBoard)
        {
            BoardPosition cell;
            do
            {
                var row = _random.Next(3) + 1;
                var column = _random.Next(3) + 1;

                cell = new BoardPosition(row, column);
            } while (!gameBoard.CanSelectCell(cell));

            return gameBoard.SelectCell(cell).Position;
        }
    }
}
