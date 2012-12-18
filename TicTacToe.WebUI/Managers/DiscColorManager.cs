using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe.WebUI.Managers
{
    public class DiscColorManager : IDiscColorManager, IDisposable
    {
        private static Dictionary<string, string> _playerAndColor;
        private static Dictionary<string, string> PlayerAndColor
        {
            get { return _playerAndColor ?? (_playerAndColor = new Dictionary<string, string>()); }
            set { _playerAndColor = value; }
        }

        private Random _randomizer;
        private Random Randomizer
        {
            get
            {
                if (_randomizer == null)
                    _randomizer = new Random();
                return _randomizer;
            }
        }

        public string GetDiscColor(char playerInitialLetter)
        {
            var key = playerInitialLetter.ToString(CultureInfo.InvariantCulture);
            string color;

            PlayerAndColor.TryGetValue(key, out color);

            if (string.IsNullOrEmpty(color))
            {
                color = GetRandomRgbColor();
                PlayerAndColor.Add(key, color); //Will probably cause issues when running several threads, but ok for now.
            }

            return color;
        }

        public string GetRandomRgbColor()
        {
            string colorStr = "rgb({0},{1},{2})";

            var r = Randomizer.Next(10, 255);
            var g = Randomizer.Next(10, 255);
            var b = Randomizer.Next(10, 255);

            return string.Format(colorStr, r, g, b);
        }

        public void ClearDiscColors()
        {
            PlayerAndColor.Clear();
        }

        public void Dispose()
        {
            PlayerAndColor = null;
        }
    }
}