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
                    //TODO: slumpa värden eller ta emot som parametrar
                    BoundaryX = 20,
                    BoundaryY = 20,
                    DiscsOnBoard = new List<DiscPosition>()
                };

            return board;
        }


        
    }
}