using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class DefinitiveState : IState
    {
        private string _state;
        public DefinitiveState()
        {
            _state = "DefinitiveState";

        }
        public string StateInfo()
        {
            return _state;
        }
    }
}