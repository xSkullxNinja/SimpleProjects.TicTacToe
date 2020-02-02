using Lamar;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class TicTacToeRegistry : ServiceRegistry
    {
        public TicTacToeRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}