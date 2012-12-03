using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using TicTacToe.Common.Entities;
using TicTacToe.Common.Interfaces;
using NUnit.Framework;

namespace TicTacToe.Common.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        GameManager _gameManager;
        
        [SetUp]
        public void InitGameManager()
        {
            var playerFactory = new Mock<IPlayerRepository>().Object;
            var boardFactory = new Mock<IBoardFactory>().Object;
            var winnerCheckerFactory = new Mock<IWinnerCheckerFactory>().Object;

            _gameManager = new GameManager(playerFactory, boardFactory, winnerCheckerFactory);
        }

        [Test]
        public void ShouldStateIllegalPlayIfOutsideBoard()
        {
            var disc = new DiscPosition { PlayerName = "Tobias", X = 0, Y = 0 };
            var board = new Board { BoundaryX = 20, BoundaryY = 20 };
            bool isLegalPlay = true;

            _gameManager.AddDisc(disc, board, out isLegalPlay);

            Assert.IsFalse(isLegalPlay);
        }

        [Test]
        public void ShouldStateIllegalPlayIfAddingOnOccupiedPosition()
        {
            var disc = new DiscPosition { PlayerName = "Tobias", X = 15, Y = 10 };
            var board = new Board
                {
                    BoundaryX = 20, 
                    BoundaryY = 20, 
                    DiscsOnBoard = new List<DiscPosition>
                        {
                            new DiscPosition { PlayerName = "T", X = 15, Y = 10 }
                        }
                };
            bool isLegalPlay = true;

            _gameManager.AddDisc(disc, board, out isLegalPlay);

            Assert.IsFalse(isLegalPlay);
        }
        
        [Test]
        public void ShouldNotThrowExceptionIfDiscsOnBoardIsNull()
        {
            var disc = new DiscPosition { PlayerName = "Tobias", X = 15, Y = 10 };
            var board = new Board
            {
                BoundaryX = 20,
                BoundaryY = 20
            };

            bool isLegalPlay = true;

            Assert.DoesNotThrow(() => _gameManager.AddDisc(disc, board, out isLegalPlay));
        }


        [Test]
        public void ShouldReturnFalseIfFewerThan4DiscsOnBoard()
        {
            var board = new Board
                {
                    BoundaryX = 20, 
                    BoundaryY = 20, 
                    DiscsOnBoard = new List<DiscPosition>
                        {
                            new DiscPosition { PlayerName = "T", X = 15, Y = 10 },
                            new DiscPosition { PlayerName = "T", X = 15, Y = 11 },
                            new DiscPosition { PlayerName = "T", X = 15, Y = 12 },
                            new DiscPosition { PlayerName = "T", X = 15, Y = 13 },
                            new DiscPosition { PlayerName = "U", X = 15, Y = 10 },
                        }
                };

            var checker = new Mock<IWinnerChecker>();
            var winningCombo = new List<DiscPosition>();
            checker.Setup(c => c.IsWinner(new List<DiscPosition>(), out winningCombo)).Returns(true);

            var checkers = new List<IWinnerChecker>() { checker.Object };

            var result = _gameManager.IsWinner(board.DiscsOnBoard, "T", checkers, out winningCombo);

            Assert.IsFalse(result);
        }
    }
}
