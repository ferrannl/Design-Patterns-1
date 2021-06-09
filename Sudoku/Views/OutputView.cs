using System;
using System.Collections.Generic;

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
            }
            else if (board.State.StateInfo() == "CandidateState")
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
                                    for (int i = 0; i < board.Fields[0].Cells.Count + 1; i++)
                                    {
                                        lineChars.Add("_");
                                    }
                                        
                                   
                                    
                                }
                                else
                                {
                                    for (int i = 0; i < board.Fields[0].Cells.Count + 1; i++)
                                    {
                                        lineChars.Add(" ");

                                    }
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
                                    for (int i = 1; i < board.Fields[0].Cells.Count + 1; i++)
                                    {
                                        if(cell.Value == i)
                                        {
                                            Console.Write(cell.Value);
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                    }
                                   
                                }
                                // empty cell
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    for (int i = 1; i < board.Fields[0].Cells.Count + 1; i++)
                                    {
                                        bool found = false;
                                        foreach (var candidate in cell.Candidates)
                                        {
                                            if(i == candidate)
                                            {
                                                found = true;
                                            }

                                        }
                                        if (found)
                                        {
                                            Console.Write(i);
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                    }
                                    
                                    
                                }
                            }
                            // currentcell
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                for (int i = 1; i < board.Fields[0].Cells.Count + 1; i++)
                                {
                                    bool found = false;
                                    foreach (var candidate in cell.Candidates)
                                    {
                                        if (i == candidate)
                                        {
                                            found = true;
                                        }

                                    }
                                    if (found)
                                    {
                                        Console.Write(i);
                                    }
                                    else
                                    {
                                        Console.Write(" ");
                                    }
                                }
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
                        if(lineChars.Count != 0)
                        {
                            lineChars.RemoveAt(lineChars.Count - 1);
                        }
                        
                        foreach (var _char in lineChars)
                        {
                            Console.Write(_char);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public void SelectPath()
        {
            Console.WriteLine("Type in the path to your puzzle:");
        }
        public void SelectMode()
        {
            Console.WriteLine("Wich mode do you want:");
            Console.WriteLine("press 0 for the no help mode or press 1 for the help mode.");
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
            Console.WriteLine("LEFT, UP, RIGHT, DOWN To move the cursor, 1-9 to set a value ");
            Console.WriteLine("S to solve, C to check current digits, E to switch between the help numbers and definitive numbers");
        }
        public void AfterSolve()
        {
            Console.WriteLine("Thank you for playing press any key to quit the game");

        }
    }
}