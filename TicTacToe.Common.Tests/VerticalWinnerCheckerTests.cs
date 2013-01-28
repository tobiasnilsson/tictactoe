using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe.Common.WinnerCheckers;
using TicTacToe.Entities;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TicTacToe.Common.Tests
{
    [TestFixture]
    public class VerticalWinnerCheckerTests
    {
        [Test]
        public void ShouldReturnIsWinner()
        {
            var checker = new VerticalWinnerChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>()
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 1},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 4},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 5},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 6},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 7},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 8},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 10}
                };

            var result = checker.IsWinner(playerDiscs, out winningCombo);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void ShouldReturnCorrectWinnerCombo()
        {
            var checker = new VerticalWinnerChecker();

            var winningCombo = new List<DiscPosition>();
            var playerDiscs = new List<DiscPosition>()
                {
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 1},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 4},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 5},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 6},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 7},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 1, Y = 8},
                    new DiscPosition(){ PlayerInitialLetter = 'T', X = 10, Y = 10}
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
