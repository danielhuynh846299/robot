using System;
using System.Collections.Generic;
namespace Robot
{
    public class TableDriver
    {
        public uint XDimension { get; set; }
        public uint YDimension { get; set; }
        public List<Robot> RobotList { get; set; }
        public int CurrentRobotNumber { get; set; }

        public TableDriver(uint x, uint y)
        {
            XDimension = x;
            YDimension = y;
            RobotList = new List<Robot>();
        }

        public bool ExcecuteCommand(string line)
        {
            var command = CommandParser(line);
            if (command.Equals(Command.NOTFOUND))
            {
                return false;
            }
            if (command.Equals(Command.PLACE))
            {

                var position = ParsePlacePosition(line);
                if (position != null)
                {
                    var robot = new Robot((Position)position)
                    {
                        ACTIVE = true
                    };
                    RobotList.Add(robot);
                    CurrentRobotNumber = RobotList.Count - 1;
                }


            }
            if (command.Equals(Command.ROBOT))
            {
                var robotNumber = GetRobotNumber(line);
                if (robotNumber != null)
                {
                    CurrentRobotNumber = (int)robotNumber - 1;
                    var robot = RobotList[CurrentRobotNumber];
                    robot.ACTIVE = true;
                }

            }
            var currentRobot = RobotList[CurrentRobotNumber];
            if (currentRobot.ACTIVE)
            {
                if (command.Equals(Command.MOVE))
                {

                    currentRobot.Position = MoveRobot(currentRobot.Position);
                }

                if (command.Equals(Command.RIGHT))
                {

                    currentRobot.Position = TurnRight(currentRobot.Position);
                }

                if (command.Equals(Command.LEFT))
                {
                    currentRobot.Position = TurnLeft(currentRobot.Position);
                }
                RobotList[CurrentRobotNumber] = currentRobot;
            }
            if (command.Equals(Command.REPORT))
            {

                Report();
            }

            return true;


        }
        public string CommandParser(string line)
        {
            if (line.Contains(Command.PLACE))
            {
                return Command.PLACE;
            }
            if (line.Contains(Command.MOVE))
            {
                return Command.MOVE;
            }
            if (line.Contains(Command.LEFT))
            {
                return Command.LEFT;
            }
            if (line.Contains(Command.RIGHT))
            {
                return Command.RIGHT;
            }
            if (line.Contains(Command.REPORT))
            {
                return Command.REPORT;
            }
            if (line.Contains(Command.ROBOT))
            {
                return Command.ROBOT;
            }
            return Command.NOTFOUND;
        }

        private Position MoveRobot(Position position)
        {
            if (position.Direction.Equals(Direction.SOUTH))
            {
                int newY = (int)position.Y - 1;
                if (newY >= 0)
                {
                    position.Y = (uint)newY;
                }

            }
            if (position.Direction.Equals(Direction.WEST))
            {
                int newX = (int)position.X - 1;
                if (newX >= 0)
                {
                    position.X = (uint)newX;
                }

            }
            if (position.Direction.Equals(Direction.NORTH))
            {
                uint newY = position.Y + 1;
                if (newY <= (YDimension - 1))
                {
                    position.Y = newY;
                }

            }
            if (position.Direction.Equals(Direction.EAST))
            {
                uint newX = position.X + 1;
                if (newX <= (XDimension - 1))
                {
                    position.X = newX;
                }

            }
            return position;

        }
        private Position TurnLeft(Position position)
        {
            if (position.Direction.Equals(Direction.SOUTH))
            {
                position.Direction = Direction.EAST;

            }
            if (position.Direction.Equals(Direction.WEST))
            {
                position.Direction = Direction.SOUTH;

            }
            if (position.Direction.Equals(Direction.NORTH))
            {
                position.Direction = Direction.WEST;

            }
            if (position.Direction.Equals(Direction.EAST))
            {
                position.Direction = Direction.NORTH;

            }
            return position;
        }
        private Position TurnRight(Position position)
        {
            if (position.Direction.Equals(Direction.SOUTH))
            {
                position.Direction = Direction.WEST;

            }
            if (position.Direction.Equals(Direction.WEST))
            {
                position.Direction = Direction.NORTH;

            }
            if (position.Direction.Equals(Direction.NORTH))
            {
                position.Direction = Direction.EAST;

            }
            if (position.Direction.Equals(Direction.EAST))
            {
                position.Direction = Direction.SOUTH;

            }
            return position;
        }
        private Position? ParsePlacePosition(string line)
        {
            var splitLine = line.Split(new char[] { ' ', ',' });
            if (splitLine.Length >= 4)
            {
                uint x;
                uint.TryParse(splitLine[1], out x);
                uint y;
                uint.TryParse(splitLine[2], out y);
                string direction = splitLine[3];
                return new Position(x, y, direction);

            }
            return null;

        }
        private int? GetRobotNumber(string line)
        {
            var splitLine = line.Split(" ");
            if (splitLine.Length >= 2)
            {
                int number;
                bool isUint = int.TryParse(splitLine[1], out number);
                if (isUint)
                {
                    return number;
                }

            }
            return null;
        }
        private void Report()
        {
            Console.WriteLine("Output:");
            Console.WriteLine(String.Format("Number of robots: {0}", RobotList.Count));
            var index = 0;
            foreach (var robot in RobotList)
            {
                int robotNumber = index + 1;
                string output = String.Format("Robot {0}: {1}", robotNumber, robot.ToString());
                Console.WriteLine(output);
                ++index;
            }
        }
    }
}
