﻿using Sudoku.Readers;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Sudoku
{
    public class BoardFactory
    {
        private IReader _reader;
        private IParser _parser;

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

        public IParser IParser
        {
            get => default;
            set
            {
            }
        }

        public IReader IReader
        {
            get => default;
            set
            {
            }
        }

        public Board Build(string filePath)
        {
            Board board = new Board();
            List<string> lines = _reader.Read(filePath);
            string fileName = Path.GetFileName(filePath);
            string pattern = @"[0-9]+x[0-9]+";
            Match m = Regex.Match(fileName, pattern);

            if (fileName.ToLower().Contains("jigsaw"))
            {
                _parser = new JigsawParser(lines, board);
            }
            else if (fileName.ToLower().Contains("samurai"))
            {
                //_parser = new SamuraiParser(lines, board);
                _parser = null;
            }
            else if (m.Success)
            {
                _parser = new NormalParser(lines, m.ToString(), board);
            }

            if (_parser != null)
            {
                board = _parser.GenerateBoard();
                return board;
            }
            return null;
        }
    }
}