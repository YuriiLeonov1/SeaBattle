using SeaBattle.Models.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Comparers
{
    internal class ShipComparer : IComparer<KeyValuePair<double, Ship>>
    {
        public int Compare(KeyValuePair<double, Ship> ship1, KeyValuePair<double, Ship> ship2)
        {
            if (ship1.Key == ship2.Key)
            {
                return 0;
            }
            else if (ship1.Key < ship2.Key)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
