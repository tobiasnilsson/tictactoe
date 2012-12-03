using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common.Entities;

namespace TicTacToe.Common.EventArgs
{
    public class GameEndEventArgs : System.EventArgs
    {
        public string Message { get; set; }
        public List<DiscPosition> WinningCombination { get; set; }
    }
}
