using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TicTacToe.Common.Entities;
using TicTacToe.Common.EventArgs;
using TicTacToe.Common.EventHandlers;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common
{
    public class GameManager : IGameManager
    {
        public event BoardEventHandler BoardUpdated;
        public event MessageEventHandler Ended;

        private IPlayerRepository _playerFactory;
        private IBoardFactory _boardFactory;
        private IWinnerCheckerFactory _winnerCheckerFactory;

        public GameManager(IPlayerRepository playerFactory, IBoardFactory boardFactory, IWinnerCheckerFactory winnerCheckerFactory)
        {
            _playerFactory = playerFactory;
            _boardFactory = boardFactory;
            _winnerCheckerFactory = winnerCheckerFactory;
        }

        protected virtual void OnBoardUpdated(BoardEventArgs e)
        {
            if (BoardUpdated != null)
                BoardUpdated(this, e);
        }

        protected virtual void OnEnded(GameEndEventArgs e)
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
            var winnerCheckers = _winnerCheckerFactory.GetWinnerCheckers();
            int playerCount = players.Count;

            while (true)
            {
                System.Threading.Thread.Sleep(10);

                //Sanity check
                if (board.DiscsOnBoard.Count == maxDiscsOnBoard || i > 10000)
                {
                    OnEnded(new GameEndEventArgs { Message = "It´s a draw!" });
                    break;
                }

                var currentPlayer = players[i % playerCount];
                bool isLegalPlay = true;
                string msg = string.Empty;
                var isWinner = false;
                var winningCombination = new List<DiscPosition>();

                var discPosition = currentPlayer.Play(board);
                discPosition.PlayerInitialLetter = currentPlayer.Name[0];

                AddDisc(discPosition, board, out isLegalPlay);

                if (!isLegalPlay)
                    msg = string.Concat("Illegal move by ", currentPlayer.Name);
                else
                    isWinner = IsWinner(board.DiscsOnBoard, discPosition.PlayerInitialLetter, winnerCheckers, out winningCombination);

                OnBoardUpdated(new BoardEventArgs { CurrentBoard = board, Message = msg, LatestDiscPosition = discPosition });

                if (isWinner)
                {
                    msg = string.Format("Winner is {0} after {1} rounds x,y={2},{3}.", currentPlayer.Name, i, discPosition.X, discPosition.Y);
                    OnEnded(new GameEndEventArgs { Message = msg, WinningCombination = winningCombination });
                    break;
                }

                i++;
            }
        }

        public void AddDisc(DiscPosition discPosition, Board board, out bool isLegalPlay)
        {
            isLegalPlay = true;

            //Outside the board
            if (discPosition.X > board.BoundaryX
                || discPosition.Y > board.BoundaryY
                || discPosition.X < 1
                || discPosition.Y < 1)
            {
                isLegalPlay = false;
            }

            if(board.DiscsOnBoard == null)
                board.DiscsOnBoard = new List<DiscPosition>();

            //On occupied position
            if (board.DiscsOnBoard.Exists(p =>
                p.X.Equals(discPosition.X) && p.Y.Equals(discPosition.Y)
                ))
            {
                isLegalPlay = false;
            }

            board.DiscsOnBoard.Add(discPosition);
        }

        public bool IsWinner(IEnumerable<DiscPosition> discsOnBoard, char playerInitialLetter, IEnumerable<IWinnerChecker> winnerCheckers, out List<DiscPosition> winningRow)
        {
            winningRow = new List<DiscPosition>();

            var filteredList = discsOnBoard.Where(d => d.PlayerInitialLetter.Equals(playerInitialLetter)).ToList();

            if (filteredList.Count() < 4)
                return false;

            foreach (var winnerChecker in winnerCheckers)
            {
                bool isWinner = winnerChecker.IsWinner(filteredList, out winningRow);
                if (isWinner)
                    return true;
            }

            return false;
        }
    }

}

