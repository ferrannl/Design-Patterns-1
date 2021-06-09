using System;

namespace Sudoku.Views
{
    internal class InputView
    {
        public string getLine()
        {
            return Console.ReadLine();
        }
        public ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            return key;
        }
    }
}