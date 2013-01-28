using System.Collections.Generic;

namespace TicTacToe.Entities.Repositories
{
    public interface IPlayerRepository
    {
        List<IPlayer> GetPlayers();
    }
}