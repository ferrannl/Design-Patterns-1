using System.Collections.Generic;

namespace Sudoku.Readers
{
    public interface IReader
    {
        List<string> Read(string filepath);
    }
}