using Hb.Mars.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Contracts
{
   public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
    }
}
