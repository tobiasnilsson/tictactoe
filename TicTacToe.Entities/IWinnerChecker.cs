using System.Collections.Generic;

namespace TicTacToe.Entities
{
    public interface IWinnerChecker
    {
        bool IsWinner(List<DiscPosition> playerDiscs, out List<DiscPosition> winningCombination);
    }
}