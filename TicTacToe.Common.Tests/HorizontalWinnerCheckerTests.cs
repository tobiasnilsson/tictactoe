using System;
using System.Collections.Generic;
using TicTacToe.Common.Entities;
using TicTacToe.Common.WinnerCheckers;
using NUnit.Framework;

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
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 4, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 8, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 9, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 11, Y = 2},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 15, Y = 15}
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
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 15, Y = 15}
                };

            var result = checker.IsWinner(playerDiscs, out winningCombo);

            Assert.IsTrue(winningCombo.Contains(playerDiscs[1]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[2]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[3]));
            Assert.IsTrue(winningCombo.Contains(playerDiscs[4]));
            Assert.IsTrue(winningCombo.Count == 4);
        }
    }
}
