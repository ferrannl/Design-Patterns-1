using Sudoku.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Sudoku
{
    public class FileReader : IReader
    {
        private IParser _parser;

        public List<string> Read(string filePath)
        {
            var text = File.ReadAllLines(filePath);
            var lines = new List<string>(text);
            return lines;
        }
    }
}