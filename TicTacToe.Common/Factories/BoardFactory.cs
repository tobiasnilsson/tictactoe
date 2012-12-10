using System.Collections.Generic;
using System.Linq;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;

namespace TicTacToe.Common.Factories
{
    public class BoardFactory : IBoardFactory
    {
        public Board GetBoard()
        {
            var board = new Board
                {
                    BoundaryX = 20,
                    BoundaryY = 20,
                    DiscsOnBoard = new List<DiscPosition>()
                };

            return board;
        }


        
    }
}