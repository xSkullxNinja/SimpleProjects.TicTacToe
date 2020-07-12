using Lamar;

using SimpleProjects.TicTacToe.ConsoleApp.TicTacToeGame;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class TicTacToeRegistry : ServiceRegistry
    {
        public TicTacToeRegistry()
        {
            Scan(_ =>
            {
                _.AssembliesFromApplicationBaseDirectory(x => x.FullName != null && x.FullName.Contains("SimpleProjects.TicTacToe"));
                _.WithDefaultConventions();
            });

            For<IGameBoard>().Use<TicTacToeBoard>();
        }
    }
}