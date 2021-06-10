using Sudoku.Enums;
using System.Collections.Generic;

namespace Sudoku
{
    //component leaf
    public class Cell
    {
        private List<int> _candidates;

        private bool _edit;

        private int _value;

        private int _box;
        public List<int> Candidates { get { return _candidates; } }
        private CheckedState _state;
        public int X { get; }
        public int Y { get; }

        public CheckedState State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }

        public bool Edit
        {
            get { return _edit; }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (_edit)
                {
                    _state = CheckedState.Unchecked;
                    if (_value == value)
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

        //cells that user inputs
        public Cell(int x, int y, int box)
        {
            X = x;
            Y = y;
            _edit = true;
            _value = 0;
            _box = box;
            _candidates = new List<int>();
            _state = CheckedState.Unchecked;

        }

        // cells that already exist
        public Cell(int x, int y, int value, int box)
        {
            X = x;
            Y = y;
            _edit = false;
            _value = value;
            _box = box;
            _candidates = new List<int>();
            _state = CheckedState.Correct;
        }

        public void AddCandidate(int helpCell)
        {
            bool found = false;
            if (_value == 0)
            {
                foreach (var helpNumber in _candidates)
                {
                    if (helpNumber == helpCell)
                    {
                        _candidates.Remove(helpNumber);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    _candidates.Add(helpCell);
                }
            }
        }
    }
}