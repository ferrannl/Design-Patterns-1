using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Cell
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }

        public Field Field
        {
            get => default;
            set
            {
            }
        }
    }
}