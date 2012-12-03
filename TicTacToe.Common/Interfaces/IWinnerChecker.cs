using System.Collections.Generic;
using TicTacToe.Common.Entities;

namespace TicTacToe.Common.Interfaces
{
    public interface IWinnerChecker
    {
        bool IsWinner(List<DiscPosition> playerDiscs, out List<DiscPosition> winningCombination);
    }
}