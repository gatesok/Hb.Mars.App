using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Contracts
{
    public interface IPlateau
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        IList<IRover> Rovers { get; set; }
        bool IsGridSizeInputAvailable(string gridSize);
        bool IsGridSizeAvailable { get; set; }
    }
}
