using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Board
    {
        private static Board _instance;
        public static Board Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Board();
                }
                return _instance;
            }
        }

        private List<Field> _fields;

        public List<Field> Fields
        {
            get { return _fields; }
        }

        public Field Field
        {
            get => default;
            set
            {
            }
        }

        public IState IState
        {
            get => default;
            set
            {
            }
        }

        public Board()
        {

        }

        public bool Check()
        {
            bool valid = false;

            return valid;
        }

    }
}