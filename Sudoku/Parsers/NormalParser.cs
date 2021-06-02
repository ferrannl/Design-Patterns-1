using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class NormalParser : IParser
    {
        private List<string> _lines;
        private Board _board;
        private int _x;
        private int _y;
        public NormalParser(List<string> lines, string xy, Board board)
        {
            _x = int.Parse(xy.Split('x')[0]);
            _y = int.Parse(xy.Split('x')[1]);
            _lines = lines;
            _board = board;
        }

        public Board GenerateBoard()
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

            _board.Xboxes = boxX;
            _board.Yboxes = boxY;

            int indexX = 0;
            int indexY = 0;

            for (int i = 0; i < _y; i++)
            {
                _columns.Add(new Column());
                _rows.Add(new Row());
                _boxes.Add(new Box());
            }

            for (int i = 0; i < _lines[0].Length; i++)
            {
                Cell cell = new Cell(indexX, indexY, int.Parse(_lines[0][i].ToString()));
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

            _board.Fields.AddRange(_fields);

            //NICK CHECK DEZE SHIT
            //foreach (var field in _fields)
            //{
            //    field.Cells.Find(cell => cell.X == _x && cell.Y == _y);

            //}


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