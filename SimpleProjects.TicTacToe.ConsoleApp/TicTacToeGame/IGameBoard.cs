namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame
{
    public interface IGameBoard
    {
        public void SetupConstraints();
        public bool HasWinner();
        public GamePiece? GetWinner();
        void PlayRandom(GamePiece player);
        void SetupBoard();
        void ClearBoard();
        bool IsCatGame();
        void PrintBoard();
    }
}
