using System.Collections.Generic;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.WinnerCheckers;

namespace TicTacToe.Common.Factories
{
    public class WinnerCheckerFactory : IWinnerCheckerFactory
    {
        public List<IWinnerChecker> GetWinnerCheckers()
        {
            //TODO: could this be done using ninject? Or use reflection.

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