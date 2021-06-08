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
                if (_edit)
                {
                   if( _value == value)
                    {
                        _value = 0;
                    }
                    else
                    {
                        _value = value;
                    }
                  
                    
                }
            }
        }
        public int Box
        {
            get { return _box; }
        }

        private List<int> _candidates;

        private bool _edit;

        private int _value;

        private int _box;

        //cells that user inputs
        public Cell(int x, int y, int box)
        {
            X = x;
            Y = y;
            _edit = true;
            _value = 0;
            _box = box;
        }

        // cells that already exist
        public Cell(int x, int y, int value, int box)
        {
            X = x;
            Y = y;
            _edit = false;
            _value = value;
            _box = box;

        }
    }
}