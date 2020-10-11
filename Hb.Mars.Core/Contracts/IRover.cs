using Hb.Mars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Contracts
{
    public interface IRover
    {
        IRoverPosition RoverPosition { get; set; }
        IPlateau Plateau { get; set; }
        IRoverPosition MoveForward();
        Direction TurnRight(Direction roverDirection);
        Direction TurnLeft(Direction roverDirection);
        public IList<IOrder> Orders { get; set; }
        void SetOrderDirection(string input);
        bool IsRoverDirectionAvailable(string roverPositionInput);
    }
}
