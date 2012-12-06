using System.Collections.Generic;
using TicTacToe.Common.Entities;
using TicTacToe.Common.EventHandlers;

namespace TicTacToe.Common.Interfaces
{
    public interface IGameManager
    {
        event BoardEventHandler BoardUpdated;
        event MessageEventHandler Ended;
        void Play();
        void AddDisc(DiscPosition discPosition, Board board, out bool isLegalPlay);
        bool IsWinner(IEnumerable<DiscPosition> discsOnBoard, char playerInitialLetter, IEnumerable<IWinnerChecker> winnerCheckers, out List<DiscPosition> winningRow);
    }
}