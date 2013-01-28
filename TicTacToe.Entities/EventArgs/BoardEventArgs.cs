namespace TicTacToe.Entities.EventArgs
{
    public class BoardEventArgs : System.EventArgs
    {
        public Board CurrentBoard { get; set; }
        public DiscPosition LatestDiscPosition { get; set; }
        public string Message { get; set; }
    }
}
