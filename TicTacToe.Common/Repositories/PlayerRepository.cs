using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<IPlayer> GetPlayers()
        {
            var players = new List<IPlayer>(2);

            // Set up MEF
            var myPath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
            var catalog = new DirectoryCatalog(myPath);
            var container = new CompositionContainer(catalog);

            // Import the exported classes
            players.AddRange(container.GetExportedValues<IPlayer>());

            return players;
        }
    }
}