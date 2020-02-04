﻿using SimpleProjects.TicTacToe.ConsoleApp.Players;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class GameManager
    {
        private readonly Board _gameBoard;

        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer;
        private bool _currentPlayerPlayer1;

        public GameManager(Board gameBoard)
        {
            _gameBoard = gameBoard;
        }

        // I don't like this for some reason.
        public void MainMenu()
        {
            _gameBoard.StartNewGame();
            Play();
        }

        public void SelectPlayerOne()
        {

        }

        public void SelectPlayerTwo()
        {

        }

        public void Play()
        {
            while (!_gameBoard.HasWinner() && !_gameBoard.IsFull())
            {
                if (_currentPlayerPlayer1)
                {
                    _currentPlayer = _player1;
                }
                else
                {
                    _currentPlayer = _player2;
                }

                var move = _currentPlayer.DetermineMove();

                _gameBoard.MarkMove(_currentPlayer.GamePiece, move);

                _currentPlayerPlayer1 = !_currentPlayerPlayer1;
            }
        }
    }
}