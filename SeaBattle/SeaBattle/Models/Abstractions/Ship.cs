using SeaBattle.Enums;

namespace SeaBattle.Models.Abstractions
{
    internal abstract class Ship
    {

        public Ship(int length, int speed, int actionRange)
        {
            Length = length;
            Speed = speed;
            ActionRange = actionRange;
        }

        public int Length { get; }

        public int Speed { get; }

        public int ActionRange { get; }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            return !(ship1 == ship2);
        }

        public static bool operator ==(Ship ship1, Ship ship2)
        {
            if (ReferenceEquals(ship1, null))
            {
                if (ReferenceEquals(ship2, null))
                {
                    return true;
                }

                return false;
            }

            var result = false;

            if (!ReferenceEquals(ship2, null))
            {
                result = ship1.Equals(ship2);
            }

            return result;
        }

        public abstract void Move(Direction direction);

        public override string ToString()
        {
            var finalString = $"Length: {this.Length} Speed: {this.Speed} ActionRange: {this.ActionRange}";

            return finalString;
        }

        public override bool Equals(object Obj)
        {
            var other = (Ship)Obj;
            return (this.Length == other.Length &&
                this.Speed == other.Speed);
        }
    }
}
