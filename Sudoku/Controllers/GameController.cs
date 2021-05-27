using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Views;

namespace Sudoku
{
    public class GameController
    {
        private readonly InputView _input;
        private readonly OutputView _output;
        private readonly BoardFactory _boardFactory;
        private Board _board;
        public GameController()
        {
            _input = new InputView();
            _output = new OutputView();
            _boardFactory = new BoardFactory(new FileReader());
            start();
        }
        private void start()
        {
            while (true)
            {
                _output.SelectPath();
                _boardFactory.Build(_input.getLine());
                //InputCommandHandler(_input.GetKey());
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