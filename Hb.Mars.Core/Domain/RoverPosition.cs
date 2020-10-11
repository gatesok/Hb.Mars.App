using Hb.Mars.Core.Contracts;
using Hb.Mars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Domain
{
   public class RoverPosition:IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public RoverPosition(Direction direction = Direction.N, int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
