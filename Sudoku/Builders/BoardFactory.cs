using Sudoku.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sudoku
{
    public class BoardFactory
    {
        private IReader _reader; 
        public BoardFactory(IReader reader)
        {
            _reader = reader;

        }
        public Board Board
        {
            get => default;
            set
            {
            }
        }

        public IParser Parser
        {
            get => default;
            set
            {
            }
        }


        public void Build(string filePath)
        {
            _reader.Read(filePath);
            string fileName = Path.GetFileName(filePath);
            string pattern = @"[0-9]+x[0-9]+";
            Match m = Regex.Match(fileName, pattern);
            if (fileName.Contains("jigsaw"))
            {
                Parser = new JigsawParser();
            }

            else if (fileName.Contains("samurai"))
            {
                Parser = new SamuraiParser();
            }

            else if (m.Success)
            {
                Console.WriteLine("hello");
                Console.WriteLine(m);
                Parser = new NormalParser();
            }
        }
    }
}