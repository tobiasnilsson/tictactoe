using System.Collections.Generic;
using TicTacToe.Common.Entities;

namespace TicTacToe.Common
{
    public class PositionComparer : IEqualityComparer<DiscPosition>
    {

        public bool Equals(DiscPosition disc1, DiscPosition disc2)
        {
            if (disc1.X < 0 || disc1.Y < 0 || disc2.X < 0 || disc2.Y < 0)
                return false;

            return disc1.X.Equals(disc2.X) && disc1.Y.Equals(disc2.Y);
        }

        public int GetHashCode(DiscPosition obj)
        {
            return obj.GetHashCode();
        }

    }
}
