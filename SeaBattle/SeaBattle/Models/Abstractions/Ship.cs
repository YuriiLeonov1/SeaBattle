using SeaBattle.Enums;

namespace SeaBattle.Models.Abstractions
{
    internal abstract class Ship
    {

        public Ship(int length, int speed, int actionRange)
        {
            this.Length = length;
            this.Speed = speed;
            this.ActionRange = actionRange;
        }

        public int Length { get; }

        public int Speed { get; }

        public int ActionRange { get; }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            if (
                ship1.GetType() == ship2.GetType() &&
                ship1.Speed == ship2.Speed &&
                ship1.Length == ship2.Length)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Ship ship1, Ship ship2)
        {
            if (
                ship1.GetType() == ship2.GetType() &&
                ship1.Speed == ship2.Speed &&
                ship1.Length == ship2.Length)
            {
                return false;
            }

            return true;
        }

        public abstract void Move(Direction direction);

        public override string ToString()
        {
            var finalString = $"Length: {this.Length} Speed: {this.Speed} ActionRange: {this.ActionRange}";

            return finalString;
        }
    }
}
