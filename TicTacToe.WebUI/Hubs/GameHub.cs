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
            var game = new GameManager(
                new PlayerRepository(@"C:\Users\Tobias Nilsson\Documents\GitHub\tictactoe\Players"), 
                new BoardFactory(),
                new WinnerCheckerFactory());

            game.BoardUpdated += game_BoardUpdated;
            game.Ended += game_Ended;

            game.Play();
        }

        protected void game_Ended(object sender, GameEndEventArgs e)
        {
            Clients.All.gameEnded(string.Concat(DateTime.Now.ToShortTimeString(),": ",e.Message));
        }

        protected void game_BoardUpdated(object sender, BoardEventArgs args)
        {
            var latestMove = args.LatestDiscPosition;

            var message = string.IsNullOrEmpty(args.Message)
                              ? string.Empty
                              : string.Concat(DateTime.Now.ToShortTimeString(),
                                              ": ",
                                              args.Message);

            Clients.All.addDisc(
                Context.ConnectionId, 
                latestMove.X, 
                latestMove.Y, 
                latestMove.PlayerName, 
                message);
        }
    }
}