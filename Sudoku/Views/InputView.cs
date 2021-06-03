using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Views
{
    class InputView
    {
        public Direction Direction
        {
            get => default;
            set
            {
            }
        }

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
