using TicTacToe.Common.EventArgs;

namespace TicTacToe.Common.EventHandlers
{
    public delegate void MessageEventHandler(object sender, GameEndEventArgs args);
}