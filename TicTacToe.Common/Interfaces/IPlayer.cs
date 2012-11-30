using TicTacToe.Common.Entities;

namespace TicTacToe.Common.Interfaces
{
    public interface IPlayer
    {
        DiscPosition Play(Board board);

        string Name { get; }
    }
}
