using System;
namespace Robot
{
    public struct Robot
    {
        public Position Position { get; set; }
        public bool ACTIVE { get; set; }
        public Robot(Position position)
        {
            Position = position;
            ACTIVE = false;
        }
        public override string ToString()
        {
            String active = ACTIVE ? "Active" : "Inactive";
            return String.Format("{0},{1},{2},{3}", active, Position.X, Position.Y, Position.Direction);

        }
    }
    public struct Position
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public string Direction { get; set; }
        public Position(uint x, uint y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

    }
}
