using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Board
    {
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

    }
}