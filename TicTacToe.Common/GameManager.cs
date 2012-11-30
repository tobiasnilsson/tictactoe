using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common.Entities;
using TicTacToe.Common.EventArgs;
using TicTacToe.Common.EventHandlers;
using TicTacToe.Common.Factories;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common
{
    public class GameManager
    {
        public event BoardEventHandler BoardUpdated;
        public event MessageEventHandler Ended;
        
        private IPlayerRepository _playerFactory;
        IBoardFactory _boardFactory;

        public GameManager(IPlayerRepository playerFactory, IBoardFactory boardFactory)
        {
            _playerFactory = playerFactory;
            _boardFactory = boardFactory;
        }
        
        protected virtual void OnBoardUpdated(BoardEventArgs e)
        {
            if (BoardUpdated != null)
                BoardUpdated(this, e);
        }

        protected virtual void OnEnded(MessageEventArgs e)
        {
            if (Ended != null)
                Ended(this, e);
        }

        public void Play()
        {
            var players = _playerFactory.GetPlayers();

            if (players.Count != 2)
                throw new NotSupportedException("Only two players can play this game. Check number of implementations of IPlayer in assembly directory.");

            var board = _boardFactory.GetBoard();

            var maxDiscsOnBoard = board.BoundaryX * board.BoundaryY;
            int i = 0;
            bool isWinner = false;

            while (!isWinner)
            {
                //Sanity check
                if (board.DiscsOnBoard.Count == maxDiscsOnBoard || i > 10000)
                {
                    OnEnded(new MessageEventArgs{Message = "Spelet avslutades oavgjort."});
                    break;
                }

                var currentPlayer = players[i % 2];
                bool isLegalPlay = true;
                string msg = string.Empty;

                var discPosition = currentPlayer.Play(board);
                discPosition.PlayerName = currentPlayer.Name[0].ToString(CultureInfo.InvariantCulture);

                isWinner = _boardFactory.AddDisc(discPosition, board, out isLegalPlay);

                if (isWinner)
                    msg = string.Format("Vinnare är {0} på {1} omgångar.", currentPlayer.Name, i);

                else if (!isLegalPlay)
                    msg = string.Concat("Oregelmässigt spel av ", currentPlayer.Name);

                OnBoardUpdated(new BoardEventArgs { CurrentBoard = board, Message = msg, LatestDiscPosition = discPosition });

                i++;
            }
        }
    }

}

