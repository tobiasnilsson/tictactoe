using TicTacToe.Common.Entities;

namespace TicTacToe.Common.Interfaces
{
    public interface IBoardFactory
    {
        Board GetBoard();
        bool AddDisc(DiscPosition discPosition, Board board, out bool isLegalPlay);
    }
}