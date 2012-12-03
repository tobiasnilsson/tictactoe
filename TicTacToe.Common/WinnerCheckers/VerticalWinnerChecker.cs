using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common.WinnerCheckers
{
    public class VerticalWinnerChecker : IWinnerChecker
    {
        public bool IsWinner(List<DiscPosition> playerDiscs, out List<Entities.DiscPosition> winningCombination)
        {
            winningCombination = new List<DiscPosition>();

            var lastOrDefault = playerDiscs.OrderBy(d => d.Y).LastOrDefault();
            if (lastOrDefault == null) return false;

            var columns = lastOrDefault.Y;

            for (int x = 1; x <= columns; x++)
            {
                var discsOnCol = playerDiscs.Where(d => d.X == x).OrderBy(d => d.Y).ToList();
                if (discsOnCol.Count < 4)
                    continue;

                var previousY = int.MinValue;
                var countInCol = 1;
                foreach (var disc in discsOnCol)
                {
                    if (previousY + 1 == disc.Y)
                    {
                        winningCombination.Add(disc);
                        if (winningCombination.Count == 4)
                            return true;
                    }
                    else
                        winningCombination.Clear();

                    previousY = disc.Y;
                }
            }

            winningCombination = new List<DiscPosition>();
            return false;
        }
    }
}
