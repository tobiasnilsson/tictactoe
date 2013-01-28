using TicTacToe.Entities.EventArgs;

namespace TicTacToe.Entities.EventHandlers
{
    public delegate void BoardEventHandler(object sender, BoardEventArgs args);
}