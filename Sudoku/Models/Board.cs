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
                Cell current = field.Cells.Find(cell => cell.X == 2 && cell.Y == 3);
                if (current != null)
                {
                    CurrentCell = current;
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
                }
            }
        }

    }
}