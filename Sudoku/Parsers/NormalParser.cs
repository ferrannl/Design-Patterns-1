using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class NormalParser : IParser
    {
        private List<string> _lines;
        private int _x;
        private int _y;
        public NormalParser(List<string> lines, string xy)
        {
            _x = int.Parse(xy.Split('x')[0]);
            _y = int.Parse(xy.Split('x')[1]);
            _lines = lines;
        }

        public List<Field> GenerateFields()
        {
            List<Field> _fields = new List<Field>();
            Field row = new Row();

            int indexX = 0;
            int indexY = 0;
            for (int i = 0; i < _lines[0].Length; i++)
            {
                row.Cells.Add(new Cell(indexX, indexY, int.Parse(_lines[0][i].ToString())));
                Console.WriteLine(_lines[0][i]);
                indexX++;
                if (indexX == (_x))
                {
                    _fields.Add(row);
                    row = new Row();
                    indexY++;
                    if (indexY == (_y))
                    {
                        indexY = 0;
                    }

                    indexX = 0;

                }
            }
            return _fields;

        }

    }
}