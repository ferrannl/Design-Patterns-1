using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Views
{
    public class OutputView
    {

        public void SelectPath()
        {
            Console.WriteLine("Type in the path to your puzzle:");
        }

        public void BuildFailed()
        {
            Console.WriteLine("Unable to build board, file contents are incorrect.");
        }
    }
}
