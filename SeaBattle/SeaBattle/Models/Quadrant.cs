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
        public Quadrant(int quadrantSoze)
        {
            _quadrSize = quadrantSoze;

            Points = new Ship[_quadrSize, _quadrSize];

            ShipsAndCenterDist = new List<KeyValuePair<double, Ship>>();

            _pythagorean = new PythagoreanTService();
        }

        public List<KeyValuePair<double, Ship>> ShipsAndCenterDist { get; }

        public Ship[,] Points { get; }

        public void Add(Ship ship, Point firstPoint, Point? secondPoint = null)
        {
            var dist = 0.0;

            if (secondPoint != null)
            {
                FillSpace(ship, firstPoint, secondPoint.Value);

                dist = GetMinDist(firstPoint, secondPoint.Value);
            }
            else
            {
                dist = _pythagorean.PythagoreanT(firstPoint.X, firstPoint.Y);

                FillSpace(ship, firstPoint);
            }

            var shipAndDist = new KeyValuePair<double, Ship>(dist, ship);

            ShipsAndCenterDist.Add(shipAndDist);
        }

        private void FillSpace(Ship ship, Point firstPoint, Point secondPoint)
        {
            if (MainLineX(firstPoint, secondPoint))
            {
                var x = firstPoint.X;
                var minY = GetMinCoord(firstPoint.Y, secondPoint.Y, out int maxY);

                for (int i = minY; i <= maxY; i++)
                {
                    Points[x, i] = ship;
                }
            }
            else
            {
                var y = firstPoint.Y;
                var minX = GetMinCoord(firstPoint.X, secondPoint.X, out int maxX);

                for (int i = minX; i <= maxX; i++)
                {
                    Points[i, y] = ship;
                }
            }
        }

        private void FillSpace(Ship ship, Point point)
        {
            Points[point.X, point.Y] = ship;
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

        private bool MainLineX(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X == secondPoint.X)
            {
                return true;
            }

            return false;
        }

    }
}
