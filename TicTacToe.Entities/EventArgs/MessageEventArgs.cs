using System.Collections.Generic;

namespace TicTacToe.Entities.EventArgs
{
    public class GameEndEventArgs : System.EventArgs
    {
        public string Message { get; set; }
        public List<DiscPosition> WinningCombination { get; set; }
    }
}
