using Hb.Mars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Domain
{
    public class TurnRightOrder : IOrder
    {
        IRover rover;

        public TurnRightOrder(IRover rover)
        {
            this.rover = rover;
        }
        public void Operation()
        {
            this.rover.MoveForward();
        }
    }
}
