using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.WebUI.Models
{
    public class IndexModel
    {
        public List<IPlayer> Players { get; set; }
    }
}