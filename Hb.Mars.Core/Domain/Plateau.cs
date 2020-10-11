using Hb.Mars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Core.Domain
{
    public class Plateau : IPlateau
    {
        public IList<IRover> Rovers { get;set; }
       public int GridX { get ; set ; }
       public int GridY { get ; set ; }

        public Plateau()
        {
            this.Rovers = new List<IRover>();
        }

        public Plateau(int gridX, int gridY)
        {
            GridX = gridX;
            GridY = gridY;
        }
        public bool IsGridSizeAvailable { get ; set ; }

        public bool IsGridSizeInputAvailable(string gridSizeInput)
        {
            IsGridSizeAvailable = false;
            if (!string.IsNullOrEmpty(gridSizeInput))
            {
                var gridSize = gridSizeInput.Split(' ');
                if (gridSize.Length == 2)
                {
                    if (int.TryParse(gridSize[0], out int gridX))
                    {
                        if (int.TryParse(gridSize[1], out int gridY))
                        {
                            GridX = gridX;
                            GridY = gridY;
                            IsGridSizeAvailable = true;
                        }
                    }

                }
            }
            return IsGridSizeAvailable;
        }
    }
}
