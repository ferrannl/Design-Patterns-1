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
            int boxX = 0;
            int boxY = 0;

            List<Field> _fields = new List<Field>();
            List<Column> _columns = new List<Column>();
            List<Row> _rows = new List<Row>();
            List<Box> _boxes = new List<Box>();

            switch (_x)
            {
                case 4:
                    boxX = 2;
                    boxY = 2;
                    break;
                case 6:
                    boxX = 3;
                    boxY = 2;
                    break;
                case 9:
                    boxX = 3;
                    boxY = 3;
                    break;
            }

            int indexX = 0;
            int indexY = 0;
            int boxCountX = 0;
            int boxCountY = 0;
            int boxIndex = 0;

            for (int i = 0; i < _y; i++)
            {
                _columns.Add(new Column());
                _rows.Add(new Row());
                _boxes.Add(new Box());
            }

            for (int i = 0; i < _lines[0].Length; i++)
            {
                _columns[indexX].Cells.Add(new Cell(indexX, indexY, int.Parse(_lines[0][i].ToString())));
                _rows[indexY].Cells.Add(new Cell(indexX, indexY, int.Parse(_lines[0][i].ToString())));
                _boxes[boxIndex].Cells.Add(new Cell(indexX, indexY, int.Parse(_lines[0][i].ToString())));
                Console.WriteLine(_lines[0][i]);
                indexX++;
                boxCountX++;
                if (boxCountX == boxX)
                {
                    boxCountX = 0;
                    boxCountY++;
                    if (boxCountY == boxY)
                    {
                        boxCountY = 0;
                    }
                    boxIndex++;
                }
                if (indexX == (_x))
                {
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