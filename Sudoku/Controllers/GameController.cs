using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Views;

namespace Sudoku
{
    public class GameController
    {
        private InputView _input;
        private OutputView _output;
        private BoardFactory _boardFactory;
        private Board _board;
        public GameController()
        {
            _input = new InputView();
            _output = new OutputView();
            _boardFactory = new BoardFactory();
            start();
        }

        private void start()
        {
            while (true)
            {
                _output.SelectPath();
                _boardFactory.Build(_input.getLine());
                InputCommandHandler(_input.GetKey());
                //_output.PrintPlayingField(_board);
            }
        }

        private void InputCommandHandler(object p)
        {
            throw new NotImplementedException();
        }

        private FileReader _fileReader;

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