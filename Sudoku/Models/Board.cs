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
            get
            {
                return _fields;
            }
            set
            {
                _fields = value;
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