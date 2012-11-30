using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Common.Entities;

namespace TicTacToe.Common
{
    public class BoardEventArgs : EventArgs
    {
        public Board CurrentBoard { get; set; }
        public DiscPosition LatestDiscPosition { get; set; }
        public string Message { get; set; }
    }
}
