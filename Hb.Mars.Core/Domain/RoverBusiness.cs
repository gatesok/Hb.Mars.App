using Hb.Mars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hb.Mars.Core.Domain
{
   public class RoverBusiness
    {
        public IRover Rover { get; set; }
        private Queue<IOrder> orders = new Queue<IOrder>();

        public RoverBusiness(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(IOrder order)
        {
            orders.Enqueue(order);
        }

        public void ProcessCommands()
        {
            while (orders.Any())
            {
                IOrder order = orders.Dequeue();
                order.Operation();
            }
        }
    }
}
