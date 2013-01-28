using System.Collections.Generic;
using System.Linq;
using TicTacToe.Entities;
using TicTacToe.Entities.Factories;

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