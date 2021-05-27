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
        public NormalParser(List<string> lines,string xy)
        {
            _x = int.Parse(xy.Split('x')[0]);
            _y = int.Parse(xy.Split('x')[1]);
            _lines = lines;
        }
    }
}