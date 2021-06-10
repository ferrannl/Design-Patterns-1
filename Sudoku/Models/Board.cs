using System.Collections.Generic;
using Sudoku.Enums;

namespace Sudoku
{
    public class Board
    {
        private int _xboxes;
        private int _yboxes;
        private Cell _currentCell;
        private IState _state;
        private IState _canidateState;
        private IState _definitiveState;

        private List<Field> _fields;

        public Cell CurrentCell
        {
            get { return _currentCell; }
            set
            {
                _currentCell = value;
            }
        }

        public List<Field> Fields
        {
            get { return _fields; }
            set
            {
            }
        }

        public IState State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }

        public Board()
        {
            _fields = new List<Field>();
            _definitiveState = new DefinitiveState();
            _canidateState = new CandidateState();
            _state = _definitiveState;
        }

        public void changeState()
        {
            if (State.StateInfo() == "CandidateState")
            {
                State = _definitiveState;
            }
            else
            {
                State = _canidateState;
            }
        }

        public bool Check()
        {
            bool valid = false;
            return valid;
        }

        public void SetStartCell()
        {
            foreach (var field in _fields)
            {
                Cell nextCell = field.Cells.Find(cell => cell.X == 0 && cell.Y == 0);
                if (nextCell != null)
                {
                    CurrentCell = nextCell;
                    break;
                }
            }
        }

        public void Move(int x, int y)
        {
            foreach (var field in _fields)
            {
                Cell nextCell = field.Cells.Find(cell => cell.X == CurrentCell.X + x && cell.Y == CurrentCell.Y + y);
                if (nextCell != null)
                {
                    CurrentCell = nextCell;
                    break;
                }
            }
        }

        public bool Solve()
        {
            Cell foundCell = this.FindEmptyCell();
            if (foundCell == null)
            {
                return true;
            }
            for (int i = 1; i < this.Fields[0].Cells.Count + 1; i++)
            {
                if (IsValid(foundCell, i))
                {
                    foundCell.Value = i;
                    if (Solve())
                    {
                        return true;
                    }
                    foundCell.Value = 0;
                }
            }
            return false;
        }

        public void FillCandidates()
        {
            foreach (var field in _fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell.Value == 0)
                        {
                            for (int i = 1; i < this.Fields[0].Cells.Count + 1; i++)
                            {
                                if (IsValid(cell, i))
                                {
                                    cell.Candidates.Add(i);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Cell FindEmptyCell()
        {
            Cell cell = null;
            foreach (var field in _fields)
            {
                if (field is Row)
                {
                    bool found = false;
                    foreach (var item in field.Cells)
                    {
                        if (item.Value == 0)
                        {
                            cell = item;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }
            return cell;
        }

        public bool IsValid(Cell cell, int value)
        {
            Field row = null;
            Field column = null;
            Field box = null;
            foreach (var field in _fields)
            {
                Cell foundCell = field.Cells.Find(c => c.X == cell.X && c.Y == cell.Y);
                if (foundCell != null)
                {
                    foundCell = null;
                    if (field is Row)
                    {
                        row = field;
                    }
                    else if (field is Column)
                    {
                        column = field;
                    }
                    else if (field is Box)
                    {
                        box = field;
                    }
                }
            }
            bool unique = true;
            foreach (var item in row.Cells)
            {
                if ((value == item.Value) && (cell != item))
                {
                    unique = false;
                    break;
                }
            }
            if (unique)
            {
                foreach (var item in column.Cells)
                {
                    if ((value == item.Value) && (cell != item))
                    {
                        unique = false;
                        break;
                    }
                }
            }
            if (unique)
            {
                foreach (var item in box.Cells)
                {
                    if ((value == item.Value) && (cell != item))
                    {
                        unique = false;
                        break;
                    }
                }
            }
            return unique;
        }

        public void CheckCells(Board solvedBoard)
        {
            int fieldIndex = 0;
            foreach (Field field in this.Fields)
            {
                if (field is Row)
                {
                    int cellIndex = 0;
                    foreach (Cell cell in field.Cells)
                    {
                        if ((cell.Edit) && (cell.Value != 0))
                        {
                            if (cell.Value == solvedBoard.Fields[fieldIndex].Cells[cellIndex].Value)
                            {
                                cell.State = CheckedState.Correct;
                            }
                            else
                            {
                                cell.State = CheckedState.Incorrect;
                            }
                        }
                        cellIndex++;
                    }
                }
                fieldIndex++;
            }
        }
    }
}