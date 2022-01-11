using SeaBattle.Comparers;
using SeaBattle.Enums;
using SeaBattle.Models.Abstractions;
using SeaBattle.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle.Models
{
    internal class GameField
    {
        private const int QuadrantCount = 4;

        public GameField(int size)
        {
            Size = size;
            QuadrantSize = size / 2;

            Field = new Quadrant[QuadrantCount]
            {
                new Quadrant(QuadrantSize),
                new Quadrant(QuadrantSize),
                new Quadrant(QuadrantSize),
                new Quadrant(QuadrantSize)
            };
        }

        public int Size { get; init; }

        public int QuadrantSize { get; init; }

        public Quadrant[] Field { get; }

        public int ShipsCount { get; }

        public bool Filled { get; }

        public Ship this[QuadrantName quadrant, int x, int y] 
        { 
            get 
            {
                return Field[(int)quadrant].Points[x, y];
            }
        }

        public bool Add(Ship ship, QuadrantName quadrant, Point firstPoint, Point secondPoint)
        {
            if (
                ship != null &&
                !Filled &&
                PointIsExist(firstPoint) &&
                PointIsExist(secondPoint) &&
                PointsOnOneLine(firstPoint, secondPoint) &&
                !CellFilled(firstPoint, quadrant) &&
                !CellFilled(secondPoint, quadrant) &&
                !AdjacentCellFilled(firstPoint, quadrant) &&
                !AdjacentCellFilled(secondPoint, quadrant))
            {
                Field[(int)quadrant].Add(ship, firstPoint, secondPoint);

                return true;
            }

            return false;
        }

        public bool Add(Ship ship, QuadrantName quadrant, Point point)
        {
            if (ship != null &&
                !Filled &&
                PointIsExist(point) &&
                !CellFilled(point, quadrant) &&
                !AdjacentCellFilled(point, quadrant))
            {
                Field[(int)quadrant].Add(ship, point);

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var ships = GetSortetdShips();
            var result = new StringBuilder();

            foreach (var ship in ships)
            {
                result.Append($"{ship} \n");
            }

            return result.ToString();
        }

        private bool CellFilled(Point point, QuadrantName quadrant)
        {
            var invalid = true;

            var fieldPoint = Field[(int)quadrant].Points[point.X, point.Y];

            if (fieldPoint == null)
            {
                invalid = false;
            }

            return invalid;
        }

        private bool AdjacentCellFilled(Point point, QuadrantName quadrantNum)
        {
            var invalid = true;

            var incX = ValidValue(point.X, '+');
            var incY = ValidValue(point.Y, '+');

            var decX = ValidValue(point.X, '-');
            var decY = ValidValue(point.Y, '-');

            var quadrant = Field[(int)quadrantNum];

            if(
                quadrant.Points[point.X, incY] == null &&
                quadrant.Points[point.X, decY] == null &&
                quadrant.Points[incX, point.Y ] == null &&
                quadrant.Points[decX, point.Y] == null &&
                quadrant.Points[incX, incY] == null &&
                quadrant.Points[decX, decY] == null &&
                quadrant.Points[decX, incY] == null &&
                quadrant.Points[incX, decY] == null)
            {
                invalid = false;
            }

            return invalid;
        }

        private int ValidValue( int num, char operation )
        {
            var validNum = 0;

            switch (operation)
            {
                case '+':
                    if (num >= QuadrantSize - 1 || num < 0)
                    {
                        validNum = num;
                    }
                    else
                    {
                        validNum = num + 1;
                    }
                    break;
                case '-':
                    if (num >= QuadrantSize || num <= 0)
                    {
                        validNum = num;
                    }
                    else
                    {
                        validNum = num - 1;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, "Invalid operation.");
            }

            return validNum;
        }

        private bool PointIsExist(Point point)
        {
            var valid = true;

            if (point.X > QuadrantSize || 
                point.Y > QuadrantSize || 
                point.X < 0 || 
                point.Y < 0)
            {
                valid = false;
            }

            return valid;
        }

        private bool PointsOnOneLine(Point firstPoint, Point secondPoint)
        {
            var valid = false;

            if (firstPoint.X == secondPoint.X ||
                firstPoint.Y == secondPoint.Y)
            {
                valid = true;
            }

            return valid;
        }

        private List<Ship> GetSortetdShips()
        {
            var ships = new List<Ship>();
            var shipsAndDist = new List<KeyValuePair<double, Ship>>();

            foreach (var quadrants in Field)
            {
                foreach (var item in quadrants.ShipsAndCenterDist)
                {
                    shipsAndDist.Add(item);
                }
            }

            shipsAndDist.Sort(new ShipComparer());

            foreach (var item in shipsAndDist)
            {
                ships.Add(item.Value);
            }

            return ships;
        }
    }
}
