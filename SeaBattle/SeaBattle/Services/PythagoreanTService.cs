using SeaBattle.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Services
{
    internal class PythagoreanTService : IPythagoreanTService
    {
        public double PythagoreanT(int x, int y)
        {
            var c = Math.Sqrt((x * x + y * y));

            return c;
        }
    }
}
