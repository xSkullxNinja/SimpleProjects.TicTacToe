namespace SimpleProjects.TicTacToe.ConsoleApp.Players
{
    public interface IPlayer
    {
        BoardMark GamePiece { get; set; }
        BoardPosition DetermineMove();
    }
}
