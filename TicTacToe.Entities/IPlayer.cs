namespace TicTacToe.Entities
{
    public interface IPlayer
    {
        DiscPosition Play(Board board);

        string Name { get; }
    }
}
