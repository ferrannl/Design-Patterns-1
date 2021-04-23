using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; set; }

        /// <summary>
        /// 0 = row
        /// 1 = column
        /// 2 = box
        /// </summary>
        public Field[] Fields { get; }

        public Cell(int x, int y, Field row, Field column, Field box)
        {
            X = x;
            Y = y;
            Fields[0] = row;
            Fields[1] = column;
            Fields[2] = box;
        }
        public Cell(int x, int y, Field row, Field column, Field box, int value)
        {
            X = x;
            Y = y;
            Fields[0] = row;
            Fields[1] = column;
            Fields[2] = box;
            Value = value;
        }



    }
}