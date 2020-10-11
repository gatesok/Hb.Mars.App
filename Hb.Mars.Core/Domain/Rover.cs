using Hb.Mars.Core.Contracts;
using Hb.Mars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Domain
{
    public class Rover:IRover
    {
        public Plateau PlateauGrid { get; set; }
        public int X { get ; set; }
        public int Y { get ; set ; }
        public Direction Direction { get; set; }
        public IPlateau Plateau { get; set; }
        public IRoverPosition RoverPosition { get; set; }
        public IList<IOrder> Orders { get; set; }
        public Rover()
        {
            this.Orders = new List<IOrder>();
        }

        public Rover(IRoverPosition roverPosition, IPlateau plateau)
        {
            this.RoverPosition = roverPosition;
            this.Plateau = plateau;
            this.Orders = new List<IOrder>();
        }

        public IRoverPosition MoveForward()
        {
            IsRoverAtValidGridBoundaries();
            _ = RoverPosition;
            IRoverPosition currentRoverPosition = RoverPosition.Direction switch
            {
                Direction.N => new RoverPosition(RoverPosition.Direction, RoverPosition.X, RoverPosition.Y + 1),
                Direction.S => new RoverPosition(RoverPosition.Direction, RoverPosition.X, RoverPosition.Y - 1),
                Direction.W => new RoverPosition(RoverPosition.Direction, RoverPosition.X - 1, RoverPosition.Y),
                Direction.E => new RoverPosition(RoverPosition.Direction, RoverPosition.X + 1, RoverPosition.Y),
                _ => throw new InvalidOperationException(),
            };
            return currentRoverPosition;
        }

        public  Direction TurnRight(Direction roverDirection)
        {
            var currentRoverDirection = roverDirection switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new InvalidOperationException(),
            };
            return currentRoverDirection;
        }

        public  Direction TurnLeft(Direction roverDirection)
        {
            var currentRoverDirection = roverDirection switch
            {
                Direction.N => Direction.W,
                Direction.E => Direction.N,
                Direction.S => Direction.E,
                Direction.W => Direction.S,
                _ => throw new InvalidOperationException(),
            };
            return currentRoverDirection;
        }


        private void IsRoverAtValidGridBoundaries()
        {
            var gridX = Plateau.GridX;
            var gridY = Plateau.GridY;
            var currentRoverPosition = RoverPosition;

            if (currentRoverPosition.X > gridX || currentRoverPosition.X < 0)
            {
                throw new Exception("Not the proper coordinate");
            }

          else  if (currentRoverPosition.Y > gridY || currentRoverPosition.Y < 0)
            {
                throw new Exception("Not the proper coordinate");
            }
        }


        public bool IsRoverDirectionAvailable(string roverPositionInput)
        {
            var roverPosition = roverPositionInput.Split(' ');
            if (roverPosition.Length == 3)
            {
               
                    var x = int.Parse(roverPosition[0]);
                    var y = int.Parse(roverPosition[1]);

                    var direction = roverPosition[2].ToUpper();
                    if (direction == "N" || direction == "S" || direction == "E" || direction == "W")
                    {
                        this.RoverPosition.Direction = (Direction)Enum.Parse(typeof(Direction), direction);
                        this.RoverPosition.X = x;
                        this.RoverPosition.Y = y;
                        return true;
                    }
               
            }
            return false;
        }

        public void SetOrderDirection(string input)
        {
            foreach (var letter in input.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        this.Orders.Add(new TurnLeftOrder(this));
                        break;
                    case 'R':
                        this.Orders.Add(new TurnRightOrder(this));
                        break;
                    case 'M':
                        this.Orders.Add(new MoveForwardOrder(this));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }


    }
}
