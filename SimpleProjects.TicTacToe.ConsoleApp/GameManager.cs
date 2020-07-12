using System;

using SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class GameManager
    {
        private readonly IGameBoard _board;

        public GameManager(IGameBoard board)
        {
            _board = board;
        }

        public void Init()
        {
            _board.SetupBoard();
            _board.SetupConstraints();
        }

        public void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                Play();
            }
        }

        public void Play()
        {
            _board.ClearBoard();
            _board.PrintBoard();
            var currentPlayer = GamePiece.X;
            while (!_board.HasWinner() && !_board.IsCatGame())
            {
                _board.PlayRandom(currentPlayer);
                currentPlayer = GetNextPlayer(currentPlayer);
                _board.PrintBoard();
                Console.ReadKey();
            }

            if (!_board.HasWinner() && _board.IsCatGame())
            {
                Console.WriteLine($"Cat Game Found.");
                _board.PrintBoard();
                Console.ReadKey();
                return;
            }
            var winner = _board.GetWinner();

            Console.WriteLine($"Winning piece is {winner}");
            _board.PrintBoard();
            Console.ReadKey();
        }

        private GamePiece GetNextPlayer(GamePiece currentPlayer)
        {
            return currentPlayer == GamePiece.X ? GamePiece.O : GamePiece.X;
        }
    }
}