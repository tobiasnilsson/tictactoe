using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TicTacToe.Common;
using TicTacToe.Common.Comparers;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;

namespace Player2
{
    [Export(typeof(IPlayer))]
    public class SecondPlayer : IPlayer
    {
        private Random Randomizer { get; set; }

        public SecondPlayer()
        {
            Randomizer = new Random();
        }

        public DiscPosition Play(Board board)
        {
            var possiblePosition = GetPossibleDiscPosition(board.DiscsOnBoard, board.BoundaryX, board.BoundaryY);

            var myMove = new DiscPosition
                {
                    X = possiblePosition.X,
                    Y = possiblePosition.Y
                };

            return myMove;
        }

        private DiscPosition GetPossibleDiscPosition(IList<DiscPosition> occupiedPositions, int boundaryX, int boundaryY)
        {
            var suggestion = new DiscPosition();
            var positionComparer = new PositionComparer();
            var maxIterations = boundaryX*boundaryY;

            do
            {
                suggestion = new DiscPosition
                {
                    X = Randomizer.Next(1, boundaryX+1),
                    Y = Randomizer.Next(1, boundaryY+1)
                };

                maxIterations--;
            } 
            while (occupiedPositions.Contains(suggestion, positionComparer) 
                && maxIterations >= 0);

            return suggestion;
        }

        public string Name
        {
            get { return "Unknown"; }
        }
    }
}
