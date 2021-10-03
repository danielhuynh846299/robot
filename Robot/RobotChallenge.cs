using System;
namespace Robot
{
    public class RobotChallenge
    {


        public static void Run(string[] commands, TableDriver tableDriver)
        {

            foreach (var command in commands)
            {

                tableDriver.ExcecuteCommand(command);
            }

        }



    }
}
