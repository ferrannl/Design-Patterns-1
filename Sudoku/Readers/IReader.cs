using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Readers
{
    public interface IReader
    {
        List<string> Read(string filepath);
    }
}
