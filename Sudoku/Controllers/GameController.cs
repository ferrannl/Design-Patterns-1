using Sudoku.Views;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Sudoku
{
    [ExcludeFromCodeCoverage]
    public class GameController
    {
        private readonly InputView _input;
        private readonly OutputView _output;
        private readonly BoardFactory _boardFactory;
        private Board _board;
        private Board _solvedBoard;
        private bool _levelSelected;
        private bool _playing;

        public GameController()
        {
            _input = new InputView();
            _output = new OutputView();
            _boardFactory = new BoardFactory(new FileReader());
            _levelSelected = false;
            _playing = false;

            start();
        }

        private void start()
        {
            while (!_levelSelected)
            {
                _output.SelectPath();
                try
                {
                    String path = _input.getLine();
                    _board = _boardFactory.Build(path);
                    _solvedBoard = _boardFactory.Build(path);
                    if (_board != null)
                    {
                        _levelSelected = true;
                    }
                    else
                    {
                        _output.RetrySelection();
                    }
                }
                catch (Exception e)
                {
                    _output.RetrySelection();
                }
            }
            _board.SetStartCell();
            _solvedBoard.SetStartCell();

           _solvedBoard.Solve();
            _playing = true;
            this.play();
        }

        private void InputCommandHandler(ConsoleKeyInfo key)
        {
            int value;
            bool isNumerical = int.TryParse(key.KeyChar.ToString(), out value);
            if (!isNumerical)
            {
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        _board.Move(-1, 0);
                        break;

                    case ConsoleKey.UpArrow:
                        _board.Move(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                        _board.Move(1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        _board.Move(0, 1);
                        break;

                    case ConsoleKey.S:
                        _board = _solvedBoard;
                        _playing = false;
                        _output.DrawBoard(_board);
                        _output.AfterSolve();
                        _input.GetKey();
                        break;

                    case ConsoleKey.E:
                        _board.changeState();
                        _solvedBoard.changeState();
                        break;
                    case ConsoleKey.C:
                        _board.CheckCells(_solvedBoard);
                        break;
                }
                _output.DrawBoard(_board);
                _output.HelpCommands();
            }
            else
            {
                if (value > 0 && value < _board.Fields[0].Cells.Count + 1)
                {
                    if (_board.State.StateInfo() == "CandidateState")
                    {
                        _board.CurrentCell.AddCandidate(value);
                    }
                    else
                    {
                        _board.CurrentCell.Value = value;
                    }
                    _output.DrawBoard(_board);
                }
                else
                {
                    _output.DrawBoard(_board);
                    _output.HelpCommands();
                }
            }
        }

        private void play()
        {
            chooseGameMode();
            _output.DrawBoard(_board);
            _output.HelpCommands();
            while (_playing)
            {
                InputCommandHandler(_input.GetKey());
            }
        }

        private void chooseGameMode()
        {
            bool modeChosen = false;
            while (!modeChosen)
            {
                _output.SelectMode();
                ConsoleKeyInfo key = _input.GetKey();
                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        modeChosen = true;
                        break;

                    case ConsoleKey.D1:
                        _board.FillCandidates();
                        modeChosen = true;

                        break;

                    default:
                        _output.SelectMode();
                        break;
                }
            }
        }
    }
}