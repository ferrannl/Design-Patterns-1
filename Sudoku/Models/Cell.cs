using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    //component leaf
    public class Cell
    {
        public List<int> Candidates { get; }
        public int X { get; }
        public int Y { get; }
        public int Value
        {
            get { return _value; }
            set
            {
                //if (_edit)
                //{
                    _value = value;
                //}
            }
        }

        private List<int> _candidates;

        private bool _edit;

        private int _value;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            _edit = true;
        }

        public Cell(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
            _edit = false;
        }
    }
}