using Lamar;

namespace SimpleProjects.TicTacToe.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var container = new Container(registry => registry.IncludeRegistry<TicTacToeRegistry>());

            var manager = container.GetInstance<GameManager>();

            manager.MainMenu();
        }
    }
}