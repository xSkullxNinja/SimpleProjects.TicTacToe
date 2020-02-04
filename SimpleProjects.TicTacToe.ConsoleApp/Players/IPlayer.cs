namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public interface IPlayer
    {
        BoardMark GamePiece { get; set; }
        BoardPosition DetermineMove();
    }
}
