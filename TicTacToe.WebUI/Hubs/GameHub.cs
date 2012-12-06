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
using TicTacToe.Common.Interfaces;

namespace TicTacToe.WebUI.Hubs
{
    [HubName("game")]
    public class GameHub : Hub
    {
        private IDiscColorManager _discColorManager;
        private IGameManager _gameManager;

        //public GameHub(IPlayerRepository playerRepository, IDiscColorManager discColorManager, IBoardFactory boardFactory, IWinnerCheckerFactory winnerCheckerFactory)
        //{
        //    _playerRepository = playerRepository;
        //    _discColorManager = discColorManager;
        //    _boardFactory = boardFactory;
        //    _winnerCheckerFactory = winnerCheckerFactory;
        //}

        public GameHub()
        {
            _discColorManager = new DiscColorManager();
            var playerRepository = new PlayerRepository(System.Web.Hosting.HostingEnvironment.MapPath("~/Players"));
            var winnerCheckerFactory = new WinnerCheckerFactory();
            var boardFactory = new BoardFactory();

            _gameManager = new GameManager(playerRepository, boardFactory, winnerCheckerFactory);
        }

        public void Play()
        {
            _gameManager.BoardUpdated += game_BoardUpdated;
            _gameManager.Ended += game_Ended;

            _gameManager.Play();
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