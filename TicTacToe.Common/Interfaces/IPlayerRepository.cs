using System.Collections.Generic;

namespace TicTacToe.Common.Interfaces
{
    public interface IPlayerRepository
    {
        List<IPlayer> GetPlayers();
    }
}