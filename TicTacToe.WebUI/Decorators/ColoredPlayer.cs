using System;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.WebUI.Decorators
{
    public class ColoredPlayer : IPlayer
    {
        public ColoredPlayer(IPlayer player)
        {
            Player = player;
        }

        public IPlayer Player { get; set; }

        public DiscPosition Play(Board board)
        {
            return Player.Play(board);
        }

        public string Name
        {
            get { return Player.Name; }
        }

        public string RgbColor { get; set; }
    }
}