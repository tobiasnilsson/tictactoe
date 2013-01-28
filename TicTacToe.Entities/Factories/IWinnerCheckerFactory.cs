using System.Collections.Generic;

namespace TicTacToe.Entities.Factories
{
    public interface IWinnerCheckerFactory
    {
        List<IWinnerChecker> GetWinnerCheckers();
    }
}