using System.Collections.Generic;

namespace TicTacToe.Common.Interfaces
{
    public interface IWinnerCheckerFactory
    {
        List<IWinnerChecker> GetWinnerCheckers();
    }
}