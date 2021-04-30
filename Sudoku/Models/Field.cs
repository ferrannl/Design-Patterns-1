using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Field
    {
        private List<Cell> _cells;
        private List<Field> _fields;

        public List<Cell> Cells
        {
            get { return _cells; }
        }

        public List<Field> Fields
        {
            get { return _fields; }
        }
    }
}