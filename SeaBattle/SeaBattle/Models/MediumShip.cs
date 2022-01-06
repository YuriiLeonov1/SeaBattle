using SeaBattle.Enums;
using SeaBattle.Models.Abstractions;

namespace SeaBattle.Models
{
    internal class MediumShip : Ship, IMediumShip
    {
        public MediumShip(int length, int speed, int actionRange)
            : base(length, speed, actionRange)
        {
        }

        public override void Move(Direction direction)
        {
            throw new System.NotImplementedException("The logic of movement is not implemented");
        }

        public void Repair()
        {
            throw new System.NotImplementedException("The logic of repair is not implemented");
        }

        public void Shooting()
        {
            throw new System.NotImplementedException("The logic of shooting is not implemented");
        }
    }
}
