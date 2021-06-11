using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class JigsawParser : IParser
    {
        private List<string> _lines;
        private Board _board;
        private int _x;
        private int _y;

        public JigsawParser(List<string> lines, Board board)
        {
            _lines = lines;
            _board = board;
        }

        public Board GenerateBoard()
        {
            List<Field> _fields = new List<Field>();
            List<Column> _columns = new List<Column>();
            List<Row> _rows = new List<Row>();
            List<Box> _boxes = new List<Box>();

            int indexX = 0;
            int indexY = 0;

            //split SumoCue
            string[] cellsStrings = _lines[0].Split(new string[] { "SumoCueV1=" }, StringSplitOptions.None)[1].Split('=');
            _x = (int)Math.Sqrt(cellsStrings.Length);
            _y = (int)Math.Sqrt(cellsStrings.Length);

            for (int i = 0; i < _y; i++)
            {
                _columns.Add(new Column());
                _rows.Add(new Row());
                _boxes.Add(new Box());
            }

            for (int i = 0; i < cellsStrings.Length; i++)
            {
                //Value of a cell
                int value = int.Parse(cellsStrings[i].Split('J')[0]);

                //Index of a box
                int boxIndex = int.Parse(cellsStrings[i].Split('J')[1]);

                Cell cell;
                if (value != 0)
                {
                    cell = new Cell(indexX, indexY, value, boxIndex);
                }
                else
                {
                    cell = new Cell(indexX, indexY, boxIndex);
                }

                _columns[indexX].Cells.Add(cell);
                _rows[indexY].Cells.Add(cell);
                _boxes[boxIndex].Cells.Add(cell);
                indexX++;
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
            _fields.AddRange(_columns);
            _fields.AddRange(_rows);
            _fields.AddRange(_boxes);

            _board.Fields.AddRange(_fields);
            return _board;
        }
    }
}