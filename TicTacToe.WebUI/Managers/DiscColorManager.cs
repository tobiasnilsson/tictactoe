using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe.WebUI.Managers
{
    public class DiscColorManager : IDiscColorManager
    {
        private static Dictionary<string, string> _playerAndColor = new Dictionary<string, string>();
        private static Dictionary<string, string> PlayerAndColor
        {
            get { return _playerAndColor; }
        }

        public string GetDiscColor(char playerInitialLetter)
        {
            var key = playerInitialLetter.ToString(CultureInfo.InvariantCulture);

            if (!PlayerAndColor.ContainsKey(key))
            {
                PlayerAndColor.Add(key, GetRandomRgbColor());
            }
            return PlayerAndColor[key];
        }

        public string GetRandomRgbColor()
        {
            const string colorStr = "rgb({0},{1},{2})";

            var random = new Random();

            var r = random.Next(10, 255);
            var g = random.Next(10, 255);
            var b = random.Next(10, 255);

            return string.Format(colorStr, r, g, b);
        }
    }
}