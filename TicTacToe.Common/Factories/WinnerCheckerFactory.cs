using System.Collections.Generic;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.WinnerCheckers;

namespace TicTacToe.Common.Factories
{
    public class WinnerCheckerFactory : IWinnerCheckerFactory
    {
        public List<IWinnerChecker> GetWinnerCheckers()
        {
            return new List<IWinnerChecker>
                {
                    new HorizontalWinnerChecker(),
                    new VerticalWinnerChecker(), 
                    new LeftToRightDiagonalChecker(),
                    new RightToLeftDiagonalChecker()
                };
        }
    }
}