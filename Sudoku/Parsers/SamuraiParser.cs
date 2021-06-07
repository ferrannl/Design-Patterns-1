using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class SamuraiParser : IParser
    {
        private List<string> _lines;
        private Board _board;
        private int _x;
        private int _y;

        public SamuraiParser(List<string> lines, Board board)
        {
            _x = 9;
            _y = 9;
            _lines = lines;
            _board = board;
        }

        public Board GenerateBoard()
        {
            throw new NotImplementedException();
        }
    }
}