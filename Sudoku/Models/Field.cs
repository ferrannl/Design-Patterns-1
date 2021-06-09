using System.Collections.Generic;

namespace Sudoku
{
    public class Field
    {
        private List<Cell> _cells;
        private List<Field> _fields;

        public Field()
        {
            _cells = new List<Cell>();
            _fields = new List<Field>();
        }

        public List<Cell> Cells
        {
            get { return _cells; }
        }

        public List<Field> Fields
        {
            get { return _fields; }
        }

        public Cell Leaf
        {
            get => default;
            set
            {
            }
        }
    }
}