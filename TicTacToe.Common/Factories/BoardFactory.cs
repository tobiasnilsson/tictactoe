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

        /// <summary>
        /// Returnerar isWinner
        /// </summary>
        /// <param name="discPosition"></param>
        /// <param name="board"></param>
        /// <param name="isLegalPlay"></param>
        /// <returns></returns>
        public bool AddDisc(DiscPosition discPosition, Board board, out bool isLegalPlay)
        {
            isLegalPlay = true;
            
            //Utanför brädet
            if (discPosition.X > board.BoundaryX
                || discPosition.Y > board.BoundaryY
                || discPosition.X < 1
                || discPosition.Y < 1)
            {
                isLegalPlay = false;
                return false;
            }
            
            //Lägger på upptagen position
            if (board.DiscsOnBoard.Exists(p =>
                p.X.Equals(discPosition.X) && p.Y.Equals(discPosition.Y)
                ))
            {
                isLegalPlay = false;
                return false;
            }

            board.DiscsOnBoard.Add(discPosition);

            //TODO: behövs denna?
            //Sortera i horisontalordning
            board.DiscsOnBoard = board.DiscsOnBoard.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

            var isWinner = IsWinner(board.DiscsOnBoard, discPosition.PlayerName);

            return isWinner;
        }

        private bool IsWinner(IEnumerable<DiscPosition> list, string playerName)
        {
            var filteredList = list.Where(d => d.PlayerName.Equals(playerName)).ToList();

            if (filteredList.Count() < 4)
                return false;

            //TODO: lägg till de två andra fallen
            //TODO: Skapa tasks för att tråda varje check?
            bool isWinner = CheckHorizontal(filteredList) || CheckVertical(filteredList);
            
            return isWinner;
        }

        /// <summary>
        /// .
        /// .
        /// .
        /// .
        /// </summary>
        /// <param name="filteredList"></param>
        /// <returns></returns>
        private bool CheckVertical(List<DiscPosition> filteredList)
        {
            var lastOrDefault = filteredList.OrderBy(d => d.Y).LastOrDefault();
            if (lastOrDefault == null) return false;

            var columns = lastOrDefault.Y;

            for (int x = 1; x <= columns; x++)
            {
                var discsOnCol = filteredList.Where(d => d.X == x).OrderBy(d => d.Y).ToList();
                if (discsOnCol.Count < 4)
                    continue;

                var previousY = int.MinValue;
                var countInCol = 1;
                foreach (var disc in discsOnCol)
                {
                    if (previousY + 1 == disc.Y)
                    {
                        countInCol++;
                        if (countInCol == 4)
                            return true;
                    }
                    else
                        countInCol = 1;

                    previousY = disc.Y;
                }
            }
            return false;
        }

        /// <summary>
        /// ....
        /// </summary>
        /// <param name="sortedList"></param>
        /// <returns></returns>
        private bool CheckHorizontal(List<DiscPosition> filteredList)
        {
            var lastOrDefault = filteredList.OrderBy(d => d.X).LastOrDefault();
            if (lastOrDefault == null) return false;

            var rows = lastOrDefault.Y;

            for (int y = 1; y <= rows; y++)
            {
                var discsOnRow = filteredList.Where(d => d.Y == y).OrderBy(d => d.X).ToList();
                if (discsOnRow.Count < 4)
                    continue;

                var previousX = int.MinValue;
                var countInRow = 1;
                foreach (var disc in discsOnRow)
                {
                    if (previousX + 1 == disc.X)
                    {
                        countInRow++;
                        if (countInRow == 4)
                            return true;
                    }
                    else
                        countInRow = 1;

                    previousX = disc.X;
                }
            }
            return false;
        }

        //    .
        //   .
        //  .
        // .

        // .
        //  .
        //   .
        //    .

        
    }
}