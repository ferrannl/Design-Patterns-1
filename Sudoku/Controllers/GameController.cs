using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class GameController
    {
        private FileReader _fileReader;

        public BoardController BoardController
        {
            get => default;
            set
            {
            }
        }

        public FileReader FileReader
        {
            get => default;
            set
            {
            }
        }

        public BoardFactory BoardFactory
        {
            get => default;
            set
            {
            }
        }

        internal Views.OutputView OutputView
        {
            get => default;
            set
            {
            }
        }

        internal Views.InputView InputView
        {
            get => default;
            set
            {
            }
        }
    }
}