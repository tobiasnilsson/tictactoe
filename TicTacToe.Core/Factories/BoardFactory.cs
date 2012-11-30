using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Common.Factories
{
    public class BoardFactory
    {
        public Board GetBoard()
        {
            var board = new Board
                {
                    //TODO: slumpa värden
                    BoundaryX = 20,
                    BoundaryY = 20,
                    DiscsOnBoard = new List<DiscPosition>()
                };

            return board;
        }

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

            var positionComparer = new PositionComparer();

            //Lägger på upptagen position
            if (board.DiscsOnBoard.Exists(p =>
                p.X.Equals(discPosition.X) && p.Y.Equals(discPosition.Y)
                ))
            {
                isLegalPlay = false;
                return false;
            }

            board.DiscsOnBoard.Add(discPosition);

            //Sortera i horisontalordning
            board.DiscsOnBoard = board.DiscsOnBoard.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

            var isWinner = IsWinner(board.DiscsOnBoard, discPosition.PlayerName);

            return isWinner;
        }

        private bool IsWinner(IEnumerable<DiscPosition> list, string playerName)
        {
            //Sortera i horisontalordning
            var filteredList = list.Where(d => d.PlayerName.Equals(playerName)).ToList();

            if (filteredList.Count() < 4)
                return false;
            
            //Horisontal
            if (CheckHorizontal(filteredList)) return true;

            //Vertical
            if (CheckVertical(filteredList)) return true;


            //TODO: lägg till de två andra fallen
            
            return false;
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
            var lastOrDefault = filteredList.OrderByDescending(d => d.Y).LastOrDefault();
            if (lastOrDefault == null) return false;

            var columns = lastOrDefault.Y;

            for (int x = 1; x <= columns; x++)
            {
                var discsOnCol = filteredList.Where(d => d.X == x).OrderByDescending(d => d.Y).ToList();
                if (discsOnCol.Count < 4)
                    continue;

                var previousY = 0;
                var countInCol = 0;
                foreach (var disc in discsOnCol)
                {
                    if (previousY + 1 == disc.X)
                    {
                        countInCol++;
                        if (countInCol == 4)
                            return true;
                    }
                    else
                        countInCol = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <param name="sortedList"></param>
        /// <returns></returns>
        private bool CheckHorizontal(List<DiscPosition> filteredList)
        {
            var lastOrDefault = filteredList.OrderByDescending(d => d.X).LastOrDefault();
            if (lastOrDefault == null) return false;

            var rows = lastOrDefault.Y;

            for (int y = 1; y <= rows; y++)
            {
                var discsOnRow = filteredList.Where(d => d.Y == y).OrderByDescending(d => d.X).ToList();
                if (discsOnRow.Count < 4)
                    continue;

                var previousX = 0;
                var countInRow = 0;
                foreach (var disc in discsOnRow)
                {
                    if (previousX + 1 == disc.X)
                    {
                        countInRow++;
                        if (countInRow == 4)
                            return true;
                    }
                    else
                        countInRow = 0;
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

        // .
        // .
        // .
        // .
        

        
    }
}