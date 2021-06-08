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
            if (board.State.StateInfo() == "DefinitiveState")
            {
                Console.Clear();
                int rowCounter = 0;
                int columnCounter = 0;
                int currentBox = 0;
                foreach (var _field in board.Fields)
                {

                    if (_field is Row)
                    {
                        List<string> lineChars = new List<string>();

                        foreach (var cell in _field.Cells)
                        {
                            Cell downerCell = null;
                            foreach (var boardField in board.Fields)
                            {
                                downerCell = boardField.Cells.Find(c => c.X == cell.X && c.Y == cell.Y + 1);
                                if (downerCell != null)
                                {
                                    break;
                                }
                            }
                            if (downerCell != null)
                            {
                                if (cell.Box != downerCell.Box)
                                // horizontal lines
                                {
                                    lineChars.Add("_ ");
                                }
                                else
                                {
                                    lineChars.Add("  ");
                                }
                            }
                            // vertical lines
                            Cell righterCell = null;
                            foreach (var boardField in board.Fields)
                            {
                                righterCell = boardField.Cells.Find(c => c.X == cell.X + 1 && c.Y == cell.Y);
                                if (righterCell != null)
                                {
                                    break;
                                }
                            }
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
                            if (righterCell != null)
                            {
                                if (cell.Box != righterCell.Box)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("|");
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                            }
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        foreach (var _char in lineChars)
                        {
                            Console.Write(_char);
                        }
                        Console.WriteLine();
                    }

                }
            }else if (board.State.StateInfo() == "CandidateState")
            {

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
            Console.WriteLine("LEFT, UP, RIGHT, DOWN, 1-9 , S to solve, C to check current digits ");
        }
    }
}
