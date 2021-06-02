using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Views
{
    public class OutputView
    {

        public void DrawBoard(Board board)
        {
            foreach (var _field in board.Fields)
            {
                if (_field is Row)
                {
                    foreach (var cell in _field.Cells)
                    {
                        if (cell.Value != 0)
                        {
                            Console.Write(cell.Value);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                Console.WriteLine();
                }
            }
        }

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
