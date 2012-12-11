using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe.Common.Entities;
using TicTacToe.Common.WinnerCheckers;

namespace TicTacToe.Common.Tests
{
    [TestFixture]
    public class LeftToRightDiagonalCheckerTests
    {
        [Test]
        public void ShouldReturnIsWinner()
        {
            var checker = new LeftToRightDiagonalChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 3},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 4},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 5},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 6},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 15, Y = 15}
                };

            var result = checker.IsWinner(playerDiscs, out winningCombo);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnCorrectWinnerCombo()
        {
            var checker = new LeftToRightDiagonalChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 3},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 4},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 5},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 12, Y = 6},
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
