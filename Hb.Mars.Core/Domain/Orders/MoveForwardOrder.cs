using Hb.Mars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Domain
{
    public class MoveForwardOrder : IOrder
    {

        IRover rover;

        public MoveForwardOrder(IRover rover)
        {
            this.rover = rover;
        }
        public void Operation()
        {
            this.rover.MoveForward();
        }
    }
}
