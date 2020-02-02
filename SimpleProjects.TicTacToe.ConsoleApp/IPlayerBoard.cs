namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public interface IPlayerBoard
    {
        public bool CanSelectCell(BoardPosition playerSelection);
        public BoardCell SelectCell(BoardPosition playerSelection);
    }
}
