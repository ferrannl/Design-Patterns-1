using Sudoku.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class BoardFactory
    {
        public BoardFactory(IReader reader)
        {
            reader = new FileReader();

        }
        public Board Board
        {
            get => default;
            set
            {
            }
        }

        public IParser IParser
        {
            get => default;
            set
            {
            }
        }


        public void Build(string filePath)
        {

        }
    }
}