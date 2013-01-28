using TicTacToe.Entities.EventArgs;

namespace TicTacToe.Entities.EventHandlers
{
    public delegate void MessageEventHandler(object sender, GameEndEventArgs args);
}