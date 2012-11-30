using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using TicTacToe.Common;
using TicTacToe.Common.Factories;

namespace TicTacToe.WebUI.Hubs
{
    [HubName("game")]
    public class GameHub : Hub
    {
        public void Play()
        {
            var game = new GameManager(new PlayerRepository(), new BoardFactory());

            game.BoardUpdated += game_BoardUpdated;
            game.Ended += game_Ended;

            game.Play();
        }

        void game_Ended(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            //TODO: skicka ut vem som vann till klienten

            //Clients.All = e.
        }

        void game_BoardUpdated(object sender, BoardEventArgs args)
        {
            //TODO: skicka ut nya positionen till klienten

            var latestMove = args.LatestDiscPosition;

            //Clients.discAdded(Context.ConnectionId, latestMove.X, latestMove.Y, latestMove.PlayerName);
        }
    }
}