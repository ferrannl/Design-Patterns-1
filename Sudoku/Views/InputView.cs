using System;
using System.Diagnostics.CodeAnalysis;

namespace Sudoku.Views
{
    [ExcludeFromCodeCoverage]
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