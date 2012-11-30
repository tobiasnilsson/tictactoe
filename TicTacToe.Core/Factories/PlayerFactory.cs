using System.Collections.Generic;

namespace TicTacToe.Common.Factories
{
    public class PlayerFactory
    {
        public List<IPlayer> GetPlayers()
        {
            var players = new List<IPlayer>(2);

            players.AddRange(new List<IPlayer>{new TobiasPlayer(), new SecondPlayer()});

            return players;
        }
    }
}