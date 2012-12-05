using System;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.AspNet.SignalR.Hubs;
using TicTacToe.Common;
using TicTacToe.Common.Entities;
using TicTacToe.Common.EventArgs;
using TicTacToe.Common.Factories;
using TicTacToe.Common.Repositories;
using TicTacToe.WebUI.Managers;

namespace TicTacToe.WebUI.Hubs
{
    [HubName("game")]
    public class GameHub : Hub
    {
        private DiscColorManager _discColorManager;

        public GameHub()
        {
            _discColorManager = new DiscColorManager();
        }

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
            var serializer = new JavaScriptSerializer();
            e.Message = string.Concat(DateTime.Now.ToShortTimeString(), ": ", e.Message);
            
            var returnMessage = serializer.Serialize(e);
            Clients.All.gameEnded(returnMessage);
        }

        protected void game_BoardUpdated(object sender, BoardEventArgs args)
        {
            var latestMove = args.LatestDiscPosition;

            var discColor = _discColorManager.GetDiscColor(args.LatestDiscPosition.PlayerInitialLetter);
            
            var message = string.IsNullOrEmpty(args.Message)
                              ? string.Empty
                              : string.Concat(DateTime.Now.ToShortTimeString(),
                                              ": ",
                                              args.Message);
            
            Clients.All.addDisc(
                Context.ConnectionId, 
                latestMove.X, 
                latestMove.Y, 
                latestMove.PlayerInitialLetter, 
                discColor,
                message);
        }
    }
}