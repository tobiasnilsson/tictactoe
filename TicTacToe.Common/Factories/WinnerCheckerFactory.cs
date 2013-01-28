using System.Collections.Generic;
using TicTacToe.Common.WinnerCheckers;
using TicTacToe.Entities;
using TicTacToe.Entities.Factories;

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