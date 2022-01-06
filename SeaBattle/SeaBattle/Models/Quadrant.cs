using SeaBattle.Models.Abstractions;
using SeaBattle.Structs;
using System;
using System.Collections.Generic;

namespace SeaBattle.Models
{
    internal class Quadrant
    {
        private readonly int _quadrSize;

        public Quadrant(int fildSoze)
        {
            _quadrSize = fildSoze / 2;

            Points = new Ship[_quadrSize, _quadrSize];
        }

        public List<KeyValuePair<double, Ship>> ShipsAndCenterDist { get; }

        public Ship[,] Points { get; }

        public bool Add(Ship ship, Point firstPoint, Point secondPoint)
        {
            throw new NotImplementedException("The logic of Add is not implemented");
        }
    }
}
