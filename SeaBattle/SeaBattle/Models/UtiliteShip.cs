using System;
using SeaBattle.Enums;
using SeaBattle.Models.Abstractions;

namespace SeaBattle.Models
{
    internal class UtiliteShip : Ship, IUtilityShip
    {
        public UtiliteShip(int length, int speed, int actionRange)
            : base(length, speed, actionRange)
        {
        }

        public override void Move(Direction direction)
        {
            throw new NotImplementedException("The logic of movement is not implemented");
        }

        public void Repair()
        {
            throw new NotImplementedException("The logic of repair is not implemented");
        }
    }
}
