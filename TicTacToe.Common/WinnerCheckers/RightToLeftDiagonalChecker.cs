using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Common.WinnerCheckers
{
    public class RightToLeftDiagonalChecker : IWinnerChecker
    {
        public bool IsWinner(List<DiscPosition> playerDiscs, out List<DiscPosition> winningCombination)
        {
            winningCombination = new List<DiscPosition>();

            if (playerDiscs.Count < 5)
                return false;

            foreach (var currentDisc in playerDiscs)
            {
                winningCombination.Clear();
                winningCombination.Add(currentDisc);

                //Hitta 5 följande discar
                for (int j = 1; j <= 5; j++)
                {
                    DiscPosition disc = currentDisc;
                    var nextDisc = playerDiscs.FirstOrDefault(d => d.X.Equals(disc.X + j) && d.Y.Equals(disc.Y - j));
                    if (nextDisc != null)
                        winningCombination.Add(nextDisc);
                    else
                        break;
                }

                if (winningCombination.Count == 5)
                    break;
            }

            return winningCombination.Count == 5;
        }
    }
}
