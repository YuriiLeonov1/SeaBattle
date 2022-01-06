using SeaBattle.Enums;
using SeaBattle.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Models
{
    internal class GameFild
    {
        public int Size { get; init; }

        public Quadrant[] Fild { get; }

        public int ShipCount { get; }

        public bool Filled { get; }


        public GameFild(int size)
        {
            Size = size;
        }

        public Ship this[QuadrantName quadrant, int x, int y] 
        { 
            get 
            {
                return this[quadrant, x, y];
            }
        }

        public bool Add(Ship ship, QuadrantName quadrant, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
