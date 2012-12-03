using System.Collections.Generic;
using System.Linq;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common.WinnerCheckers
{
    public class HorizontalWinnerChecker : IWinnerChecker
    {
        public bool IsWinner(List<DiscPosition> playerDiscs, out List<DiscPosition> winningCombination)
        {
            winningCombination = new List<DiscPosition>();

            var lastOrDefault = playerDiscs.OrderBy(d => d.X).LastOrDefault();
            if (lastOrDefault == null) return false;

            var rows = lastOrDefault.Y;

            for (int y = 1; y <= rows; y++)
            {
                var discsOnRow = playerDiscs.Where(d => d.Y == y).OrderBy(d => d.X).ToList();
                if (discsOnRow.Count < 4)
                    continue;

                var previousX = int.MinValue;
                
                foreach (var disc in discsOnRow)
                {
                    if (previousX + 1 == disc.X)
                    {
                        winningCombination.Add(disc);
                        if (winningCombination.Count == 4)
                            return true;
                    }
                    else
                        winningCombination.Clear();

                    previousX = disc.X;
                }
            }

            winningCombination = new List<DiscPosition>();
            return false;
        }
    }
}
