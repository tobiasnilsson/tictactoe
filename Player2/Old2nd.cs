using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TicTacToe.Common;

namespace Player2
{
    public class Old2nd : IPlayer
    {
        private Random Randomizer { get; set; }

        public Old2nd(string name)
        {
            Name = name;
            Randomizer = new Random();
        }

        public DiscPosition Play(Board board)
        {
            var possiblePosition = GetPossibleDiscPosition(board.DiscsOnBoard, board.BoundaryX, board.BoundaryY);

            var myMove = new DiscPosition
                {
                    X = possiblePosition.X,
                    Y = possiblePosition.Y
                };

            return myMove;
        }

        private DiscPosition GetPossibleDiscPosition(IList<DiscPosition> occupiedPositions, int boundaryX, int boundaryY)
        {
            var opponentsMoves = occupiedPositions.Where(d => d.PlayerName != this.Name[0].ToString(CultureInfo.InvariantCulture));
            var MyMoves = occupiedPositions.Where(d => d.PlayerName == this.Name[0].ToString(CultureInfo.InvariantCulture));
            List<List<DiscPosition>> OpponentsCombinations = new List<List<DiscPosition>>();
            List<List<DiscPosition>> MyCombinations = new List<List<DiscPosition>>();

            GetHorizontelOpponentCombinations(ref OpponentsCombinations, opponentsMoves, boundaryX, boundaryY);
            GetVerticalOpponentCombinations(ref OpponentsCombinations, opponentsMoves, boundaryX, boundaryY);
            GetHorizontelMyCombinations(ref MyCombinations, MyMoves, boundaryX, boundaryY);
            GetVerticalMyCombinations(ref MyCombinations, MyMoves, boundaryX, boundaryY);
            if (OpponentsCombinations.Count() > 0)
            {
                return DefensiveMove(OpponentsCombinations, boundaryX, boundaryY, occupiedPositions);
            }
            else
            {
                if (MyMoves.Count() == 0)
                {
                    return RandomMove(occupiedPositions, boundaryX, boundaryY);
                }
                var attackMove = AttackMove(MyCombinations, boundaryX, boundaryY, occupiedPositions, MyMoves);
                if (attackMove != null)
                {
                    return attackMove;
                }
                return RandomMove(occupiedPositions, boundaryX, boundaryY);
            }
        }

        private DiscPosition AttackMove(List<List<DiscPosition>> MyCombinations, int boundaryX, int boundaryY, IList<DiscPosition> occupiedPositions, IEnumerable<DiscPosition> MyMoves)
        {
            if (MyCombinations.Count == 0)
            {
                foreach (var move in MyMoves.ToList())
                {
                   
                    var positionComparer = new PositionComparer();
                    var move1 = ObjectCopier.Clone(move);
                    move1.X++;
                    if (!occupiedPositions.Contains(move1, positionComparer) && move1.X < boundaryX && move1.X > 0)
                    {
                        return move1;
                    }
                    else
                    {
                        var move2 = ObjectCopier.Clone(move);
                        move2.X--;
                        if (!occupiedPositions.Contains(move2, positionComparer) && move2.X < boundaryX && move2.X > 0)
                        {
                            return move2;
                        }
                        else
                        {
                            var move3 = ObjectCopier.Clone(move);
                            move3.Y++;
                            if (!occupiedPositions.Contains(move3, positionComparer) && move3.Y < boundaryY && move3.Y > 0)
                            {
                                return move3;
                            }
                            else
                            {
                                var move4 = ObjectCopier.Clone(move);
                                move4.Y--;
                                if (!occupiedPositions.Contains(move4, positionComparer) && move4.Y < boundaryY && move4.Y > 0)
                                {
                                    return move4;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var attackMove = defensiveMoveHorizontal(MyCombinations, boundaryX, boundaryY, occupiedPositions);
                if (attackMove != null)
                {
                    return attackMove;
                }
                
            }
            return null;
        }

      
        private void GetHorizontelMyCombinations(ref List<List<DiscPosition>> MyCombinations, IEnumerable<DiscPosition> MyMoves, int boundaryX, int boundaryY)
        {

            for (int y = boundaryY; y >= 1; y--)
            {
                var vertical = MyMoves.Where(d => d.Y == y).Select(d => d.X).ToList();

                for (int x = 0; x < vertical.Count() - 1; x++)
                {
                    List<DiscPosition> comb = new List<DiscPosition>();
                    if (vertical[x] + 1 == vertical[x + 1])
                    {
                        var Disc1 = new DiscPosition
                        {
                            X = vertical[x],
                            Y = y
                        };
                        var Disc2 = new DiscPosition
                        {
                            X = vertical[x + 1],
                            Y = y
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        MyCombinations.Add(comb);
                    }
                    else if (vertical[x] + 2 == vertical[x + 1])
                    {
                        var Disc1 = new DiscPosition
                        {
                            X = vertical[x],
                            Y = y
                        };
                        var Disc2 = new DiscPosition
                        {
                            X = vertical[x + 1],
                            Y = y
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        MyCombinations.Add(comb);
                    }

                }

            }
        }


        private void GetVerticalMyCombinations(ref List<List<DiscPosition>> MyCombinations, IEnumerable<DiscPosition> MyMoves, int boundaryX, int boundaryY)
        {

        }

        private DiscPosition DefensiveMove(List<List<DiscPosition>> combinations, int boundaryX, int boundaryY, IList<DiscPosition> occupiedPositions)
        {
            var DefensiveMoveHorizontal = defensiveMoveHorizontal(combinations, boundaryX, boundaryY, occupiedPositions);
            if (DefensiveMoveHorizontal != null)
            {
                return DefensiveMoveHorizontal;
            }
            var DefensiveMoveVertical = defensiveMoveVertical(combinations, boundaryX, boundaryY, occupiedPositions);
            if (DefensiveMoveVertical != null)
            {
                return DefensiveMoveVertical;
            }
            return RandomMove(occupiedPositions, boundaryX, boundaryY);
        }

        private DiscPosition defensiveMoveVertical(List<List<DiscPosition>> combinations, int boundaryX, int boundaryY, IList<DiscPosition> occupiedPositions)
        {
            foreach (var combi in combinations)
            {
                var firstDisc = new DiscPosition();
                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0)
                    {
                        firstDisc = combi[0];
                    }
                    else
                    {
                        var positionComparer = new PositionComparer();
                        if (combi[1].X == firstDisc.X && firstDisc.Y + 1 == combi[1].Y)
                        {

                            var suggestion = new DiscPosition
                            {
                                Y = combi[1].Y + 1,
                                X = firstDisc.X
                            };
                            //nere
                            if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.Y < boundaryY && suggestion.Y > 0)
                            {
                                return suggestion;
                            }
                            else
                            {
                                suggestion = new DiscPosition
                                {
                                    Y = firstDisc.Y - 1,
                                    X = firstDisc.X
                                };//uppe
                                if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.Y < boundaryY && suggestion.Y > 0)
                                {
                                    return suggestion;
                                }

                            }

                        }
                        else if (combi[1].X == firstDisc.X && firstDisc.Y + 2 == combi[1].Y)
                        {
                            var suggestion = new DiscPosition
                            {
                                Y = firstDisc.Y + 1,
                                X = firstDisc.X
                            };
                            if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.Y < boundaryY && suggestion.Y > 0)
                            {
                                return suggestion;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private DiscPosition defensiveMoveHorizontal(List<List<DiscPosition>> combinations, int boundaryX, int boundaryY, IList<DiscPosition> occupiedPositions)
        {
            foreach (var combi in combinations)
            {
                var firstDisc = new DiscPosition();
                var positionComparer = new PositionComparer();
                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0)
                    {
                        firstDisc = combi[0];
                    }
                    else
                    {
                        //samma rad horizontal XX
                        if (combi[1].Y == firstDisc.Y && firstDisc.X + 1 == combi[1].X)
                        {
                            var suggestion = new DiscPosition
                            {
                                X = combi[1].X + 1,
                                Y = firstDisc.Y
                            };
                            //XX_
                            if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.X < boundaryX && suggestion.X > 0)
                            {
                                return suggestion;
                            }
                            else
                            {
                                suggestion = new DiscPosition
                                {
                                    X = firstDisc.X - 1,
                                    Y = firstDisc.Y
                                };//_XX0
                                if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.X < boundaryX && suggestion.X > 0)
                                {
                                    return suggestion;
                                }

                            }
                        }
                        else if (combi[1].Y == firstDisc.Y && firstDisc.X + 2 == combi[1].X)
                        {
                            var suggestion = new DiscPosition
                            {
                                X = firstDisc.X + 1,
                                Y = firstDisc.Y
                            };
                            //X_X
                            if (!occupiedPositions.Contains(suggestion, positionComparer) && suggestion.X < boundaryX && suggestion.X > 0)
                            {
                                return suggestion;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private DiscPosition RandomMove(IList<DiscPosition> occupiedPositions, int boundaryX, int boundaryY)
        {
            var suggestion = new DiscPosition
            {
                X = Randomizer.Next(1, boundaryX),
                Y = Randomizer.Next(1, boundaryY)
            };

            var positionComparer = new PositionComparer();

            while (occupiedPositions.Contains(suggestion, positionComparer))
            {
                suggestion = new DiscPosition
                {
                    X = Randomizer.Next(1, boundaryX),
                    Y = Randomizer.Next(1, boundaryY)
                };
            }
            return suggestion;
        }

        private void GetHorizontelOpponentCombinations(ref List<List<DiscPosition>> combinations, IEnumerable<DiscPosition> opponentsMoves, int boundaryX, int boundaryY)
        {
            for (int y = boundaryY; y >= 1; y--)
            {
                var vertical = opponentsMoves.Where(d => d.Y == y).Select(d => d.X).ToList();

                for (int x = 0; x < vertical.Count() - 1; x++)
                {
                    List<DiscPosition> comb = new List<DiscPosition>();
                    if (vertical[x] + 1 == vertical[x + 1])
                    {

                        var Disc1 = new DiscPosition
                        {
                            X = vertical[x],
                            Y = y
                        };
                        var Disc2 = new DiscPosition
                        {
                            X = vertical[x + 1],
                            Y = y
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        combinations.Add(comb);
                    }
                    else if (vertical[x] + 2 == vertical[x + 1])
                    {
                        var Disc1 = new DiscPosition
                        {
                            X = vertical[x],
                            Y = y
                        };
                        var Disc2 = new DiscPosition
                        {
                            X = vertical[x + 1],
                            Y = y
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        combinations.Add(comb);
                    }
                }
            }
        }
        private void GetVerticalOpponentCombinations(ref List<List<DiscPosition>> combinations, IEnumerable<DiscPosition> opponentsMoves, int boundaryX, int boundaryY)
        {
            for (int x = boundaryX; x >= 1; x--)
            {
                var horizontel = opponentsMoves.Where(d => d.X == x).Select(d => d.Y).ToList();

                for (int y = 0; y < horizontel.Count() - 1; y++)
                {
                    List<DiscPosition> comb = new List<DiscPosition>();
                    if (horizontel[y] + 1 == horizontel[y + 1])
                    {
                        var Disc1 = new DiscPosition
                        {
                            Y = horizontel[y],
                            X = x
                        };
                        var Disc2 = new DiscPosition
                        {
                            Y = horizontel[y + 1],
                            X = x
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        combinations.Add(comb);
                    }
                    else if (horizontel[y] + 2 == horizontel[y + 1])
                    {
                        var Disc1 = new DiscPosition
                        {
                            Y = horizontel[y],
                            X = x
                        };
                        var Disc2 = new DiscPosition
                        {
                            Y = horizontel[y + 1],
                            X = x
                        };
                        comb.Add(Disc1);
                        comb.Add(Disc2);
                        combinations.Add(comb);
                    }
                }
            }
        }
        public string Name { get; set; }
      
    }
}

public static class ObjectCopier
{
    /// <summary>
    /// Perform a deep Copy of the object.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T Clone<T>(T source)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", "source");
        }

        // Don't serialize a null object, simply return the default for that object
        if (Object.ReferenceEquals(source, null))
        {
            return default(T);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}