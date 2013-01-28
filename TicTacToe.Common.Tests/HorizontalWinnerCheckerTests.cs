using System;
using System.Collections.Generic;
using TicTacToe.Common.WinnerCheckers;
using NUnit.Framework;
using TicTacToe.Entities;

namespace TicTacToe.Common.Tests
{
    [TestFixture]
    public class HorizontalWinnerCheckerTests
    {
        [Test]
        public void ShouldReturnIsWinner()
        {
            var checker = new HorizontalWinnerChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 8, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 2, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 7, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 15, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 2, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 7, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 7, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 17, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 6, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 7, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 16, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 6, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 7, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 3, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 20, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 7, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 17, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 2, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 17, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 6, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 6, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 13, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 8, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 8, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 3, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 15, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 14, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 6 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 17, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 12, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 1 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 8, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 13, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 17, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 15, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 7, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 5, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 4, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 16, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 6, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 17, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 13, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 2, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 17, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 9, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 18, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 10 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 14, Y = 20 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 7, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 5, Y = 2 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 6, Y = 11 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 18, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 13, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 7 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 9 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 20, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 17, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 14, Y = 4 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 11, Y = 8 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 17 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 6, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 16 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 15, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 16, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 19, Y = 15 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 3, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 15, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 12 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 10, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 12, Y = 3 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 2, Y = 18 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 1, Y = 5 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 19, Y = 14 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 15, Y = 19 },
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 17, Y = 13 },
                    new DiscPosition(){ PlayerInitialLetter = 'U', X = 3, Y = 6 }
                };

            var result = checker.IsWinner(playerDiscs, out winningCombo);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnCorrectWinnerCombo()
        {
            var checker = new HorizontalWinnerChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 15, Y = 15}
                };

            var result = checker.IsWinner(playerDiscs, out winningCombo);

            Assert.IsTrue(winningCombo.Contains(playerDiscs[1]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[2]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[3]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[4]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[5]));
            Assert.IsTrue(winningCombo.Count == 5);
        }


    }
}
