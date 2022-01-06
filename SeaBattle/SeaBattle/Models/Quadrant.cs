using SeaBattle.Models.Abstractions;
using SeaBattle.Services;
using SeaBattle.Structs;
using System;
using System.Collections.Generic;

namespace SeaBattle.Models
{
    internal class Quadrant
    {
        private readonly int _quadrSize;
        private readonly PythagoreanTService _pythagorean;
        public Quadrant(int fildSoze)
        {
            _quadrSize = fildSoze / 2;

            Points = new Ship[_quadrSize, _quadrSize];

            ShipsAndCenterDist = new List<KeyValuePair<double, Ship>>();

            _pythagorean = new PythagoreanTService();
        }

        public List<KeyValuePair<double, Ship>> ShipsAndCenterDist { get; }

        public Ship[,] Points { get; }

        public void Add(Ship ship, Point firstPoint, Point secondPoint, bool mainLineX)
        {
            var dist = GetMinDist(firstPoint, secondPoint);
            var shipAndDist = new KeyValuePair<double, Ship>(dist, ship);

            FillSpace(ship, firstPoint, secondPoint, mainLineX);

            ShipsAndCenterDist.Add(shipAndDist);
        }

        private void FillSpace(Ship ship, Point firstPoint, Point secondPoint, bool mainLineX)
        {
            if (mainLineX)
            {
                var y = firstPoint.Y;
                
                var minX = GetMinCoord(firstPoint.X, secondPoint.X, out int maxX);

                for (int i = minX; i <= maxX; i++)
                {
                    Points[i, y] = ship;
                }
            }
            else
            {
                var x = firstPoint.X;

                var minY = GetMinCoord(firstPoint.Y, secondPoint.Y, out int maxY);

                for (int i = minY; i <= maxY; i++)
                {
                    Points[x, i] = ship;
                }
            }
        }

        private int GetMinCoord(int firstPoint, int secondPoint, out int maxCoord)
        {
            if (firstPoint < secondPoint)
            {
                maxCoord = secondPoint;
                return firstPoint;
            }
            else
            {
                maxCoord = firstPoint;
                return secondPoint;
            }
        }

        private double GetMinDist(Point firstP, Point secondP)
        {
            var dist1 = _pythagorean.PythagoreanT(firstP.X, firstP.Y);
            var dist2 = _pythagorean.PythagoreanT(secondP.X, secondP.Y);

            var min = Math.Min(dist1, dist2);

            return min;
        }

    }
}
