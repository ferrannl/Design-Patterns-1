using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Board
    {
        private int _xboxes;
        private int _yboxes;
        private Cell _currentCell;

        public Cell CurrentCell
        {
            get { return _currentCell; }
            set
            {
                _currentCell = value;
            }
        }
        public int Xboxes
        {
            get { return _xboxes; }
            set
            {
                _xboxes = value;
            }
        }

        public int Yboxes
        {
            get { return _yboxes; }
            set
            {
                _yboxes = value;
            }
        }

        private List<Field> _fields;

        public List<Field> Fields
        {
            get { return _fields; }
            set
            {

            }
        }

        public IState IState
        {
            get => default;
            set
            {
            }
        }

        public Board()
        {
            _fields = new List<Field>();
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
            if (cell != null)
            {
                for (int i = 1; i < this.Fields[0].Cells.Count + 1; i++)
                {
                    cell.Value = i;
                    if (IsValid(cell))
                    {
                        if (Solve())
                        {
                            return true;
                        }
                    }

                }
                return false;
            }
            else {
                return true;
            }

            

        }
        public bool IsValid(Cell cell)
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
                    if(field is Row)
                    {
                        row = field;
                    }else if(field is Column)
                    {
                        column = field;
                    }else if(field is Box)
                    {
                        box = field;
                    }
                }
            }
            bool unique = true;
            foreach (var item in row.Cells)
            {

                if((cell.Value == item.Value) && (cell != item))
                {
                    unique = false;
                    break;
                }
            }
            if (unique)
            {
                foreach (var item in column.Cells)
                {

                    if ((cell.Value == item.Value) && (cell != item))
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
                    if ((cell.Value == item.Value) && (cell != item))
                    {
                        unique = false;
                        break;
                    }
                }
            }
            return unique;
        }

    }
}