namespace Sudoku
{
    public class CandidateState : IState
    {
        private string _state;
        public CandidateState()
        {
            _state = "CandidateState";
        }
        public string StateInfo()
        {
            return _state;
        }
    }
}