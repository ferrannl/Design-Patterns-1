using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Field
    {
        private List<Cell> _cells;

        public List<Cell> Cells
        {
            get { return _cells; }
        }
    }
}