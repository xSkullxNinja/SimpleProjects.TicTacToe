namespace SimpleProjects.TicTacToe.ConsoleApp.Players
{
    public class UserPlayer : IPlayer
    {
        public BoardMark GamePiece { get; set; }
        public BoardPosition DetermineMove(IPlayerBoard gameBoard)
        {
            var cell = new BoardPosition(0,0);
            gameBoard.CanSelectCell(cell);
            return gameBoard.SelectCell(cell).Position;
        }
    }
}
