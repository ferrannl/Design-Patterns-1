namespace Sudoku
{
    internal class Game
    {
        public GameController GameController
        {
            get => default;
            set
            {
            }
        }

        private static void Main(string[] args)
        {
            GameController gameController = new GameController();
        }
    }
}