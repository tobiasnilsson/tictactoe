using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicTacToe.Common.Interfaces;
using TicTacToe.WebUI.Decorators;

namespace TicTacToe.WebUI.Models
{
    public class IndexModel
    {
        public IEnumerable<ColoredPlayer> Players { get; set; }
    }
}