using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using TicTacToe.Common;
using TicTacToe.Common.EventArgs;
using TicTacToe.Common.Factories;
using TicTacToe.Common.Repositories;

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

        protected void game_Ended(object sender, MessageEventArgs e)
        {
            Clients.All.addMessage(e.Message);
        }

        protected void game_BoardUpdated(object sender, BoardEventArgs args)
        {
            var latestMove = args.LatestDiscPosition;

            Clients.All.addDisc(Context.ConnectionId, latestMove.X, latestMove.Y, latestMove.PlayerName);
        }
    }
}