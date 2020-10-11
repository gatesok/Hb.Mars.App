using Hb.Mars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hb.Mars.Business
{
   public class RoverBusiness
    {
        public IRover Rover { get; set; }
        private Queue<IOrder> commands = new Queue<IOrder>();

        public RoverBusiness(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(IOrder command)
        {
            commands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (commands.Any())
            {
                IOrder command = commands.Dequeue();
                command.Operation();
            }
        }
    }
}
