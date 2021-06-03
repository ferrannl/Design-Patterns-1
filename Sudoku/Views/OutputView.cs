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
            Console.Clear();
            int rowCounter = 0;
            int columnCounter = 0;
            Console.Write("|");
            foreach (var _field in board.Fields)
            {
                // horizontal lines
                if (rowCounter == board.Xboxes)
                {
                    rowCounter = 0;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    string result = new string('-', _field.Cells.Count() + 3);
                    Console.WriteLine(result);
                }
                if (_field is Row)
                {
                    foreach (var cell in _field.Cells)
                    {
                        // vertical lines
                        if (columnCounter == board.Yboxes)
                        {
                            columnCounter = 0;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                        }
                        // all cells except current cell

                        if (cell != board.CurrentCell)
                        {
                            // cell with value
                            if (cell.Value != 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(cell.Value);
                            }
                            // empty cell
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                            }
                        }
                        // currentcell
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(cell.Value);
                        }
                        columnCounter++;
                    }
                    rowCounter++;
                    Console.WriteLine();
                }
            }
        }

        public void SelectPath()
        {
            Console.WriteLine("Type in the path to your puzzle:");
        }

        public void RetrySelection()
        {
            Console.WriteLine("Please enter a valid path to a puzzle file.");
        }

        public void BuildFailed()
        {
            Console.WriteLine("Unable to build board, file contents are incorrect.");
        }

        public void HelpCommands()
        {
            Console.WriteLine("LEFT, UP, RIGHT, DOWN, ");
        }
    }
}
