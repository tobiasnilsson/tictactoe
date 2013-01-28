using System.Collections.Generic;
using System.Linq;
using TicTacToe.Entities;

namespace TicTacToe.Common.WinnerCheckers
{
    public class HorizontalWinnerChecker : IWinnerChecker
    {
        public bool IsWinner(List<DiscPosition> playerDiscs, out List<DiscPosition> winningCombination)
        {
            winningCombination = new List<DiscPosition>();

            var lastOrDefault = playerDiscs.OrderBy(d => d.Y).LastOrDefault();
            if (lastOrDefault == null) return false;

            var rows = lastOrDefault.Y;

            for (int y = 1; y <= rows; y++)
            {
                var discsOnRow = playerDiscs.Where(d => d.Y == y).OrderBy(d => d.X).ToList();
                if (discsOnRow.Count < 5)
                    continue;

                var previousDisc = discsOnRow.First();
                winningCombination.Clear();
                winningCombination.Add(previousDisc);

                foreach (var disc in discsOnRow.Skip(1))
                {
                    if (previousDisc.X + 1 != disc.X)
                        winningCombination.Clear();

                    winningCombination.Add(disc);

                    if (winningCombination.Count == 5)
                        return true;

                    previousDisc = disc;
                }
            }

            winningCombination = new List<DiscPosition>();
            return false;
        }
    }
}
