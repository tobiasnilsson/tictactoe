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
                if (discsOnCol.Count < 5)
                    continue;

                var previousDisc = discsOnCol.First();
                winningCombination.Clear();
                winningCombination.Add(previousDisc);
                
                foreach (var disc in discsOnCol.Skip(1))
                {
                    if (previousDisc.Y + 1 != disc.Y)
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
