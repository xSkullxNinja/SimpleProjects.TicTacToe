namespace SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame.Constraints
{
    public interface IBoardConstraint
    {
        bool CheckConstraint();
        GamePiece? GetConstraintValue();
    }
}
