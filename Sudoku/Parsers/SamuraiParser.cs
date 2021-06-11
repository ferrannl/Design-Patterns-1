using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sudoku
{
    [ExcludeFromCodeCoverage]
    public class SamuraiParser : IParser
    {
        private List<string> _lines;
        private Board _board;
        private int _x;
        private int _y;
        private int _yOuter;

        private int _xOuter;
        private int _skip;


        public SamuraiParser(List<string> lines, Board board)
        {
            _x = 9;
            _y = 9;
            _xOuter = 21;
            _yOuter = 21;
            _skip = 3;
            _lines = lines;
            _board = board;
        }

        public Board GenerateBoard()
        {
            int boxX = 3;
            int boxY = 3;

            List<Field> _fields = new List<Field>();
            List<Field> _fieldsOuter = new List<Field>();
            List<Column> _columns = new List<Column>();
            List<Column> _columnsOuter = new List<Column>();
            List<Row> _rows = new List<Row>();
            List<Row> _rowsOuter = new List<Row>();
            List<Box> _boxes = new List<Box>();
            List<Box> _boxesOuter = new List<Box>();



            //bouta smoke sum crack tudututu


            int lineIndex = 0;
            foreach (var line in _lines)
            {
            int indexX = 0;
            int indexY = 0;

            for (int i = 0; i < _y; i++)
            {
                _columns.Add(new Column());
                _rows.Add(new Row());
                _boxes.Add(new Box());
            }

            for (int i = 0; i < line.Length; i++)
            {
                Cell cell;
                if (int.Parse(line[i].ToString()) != 0)
                {
                    cell = new Cell(indexX, indexY, int.Parse(line[i].ToString()), AssignSudokuBox(i, boxY, boxX));
                }
                else
                {
                    cell = new Cell(indexX, indexY, AssignSudokuBox(i, boxY, boxX));
                }

                _columns[indexX].Cells.Add(cell);
                _rows[indexY].Cells.Add(cell);
                _boxes[AssignSudokuBox(i, boxY, boxX)].Cells.Add(cell);
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
                _boxesOuter.Add(new Box());
                _boxesOuter[lineIndex].Fields.AddRange(_fields);
                lineIndex++;
            }


            _board.Fields.AddRange(_fields);
            return _board;
        }

        public int AssignSudokuBox(int rowIndex, int m, int n)
        {
            // index, if devided to pieces n x 1
            int nChunkIndex = rowIndex / n;

            // every row has m of those pieces and there are m rows in each box
            int row = nChunkIndex / (m * m);

            int column = nChunkIndex % m;

            int result = column + row * m;

            return result;
        }
    }
}