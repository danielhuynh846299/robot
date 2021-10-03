using System;


namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            TableDriver tableDriver = new TableDriver(5, 5);
            var inputFile = "input.txt";
            var commands = Helper.GetCommands(inputFile);
            RobotChallenge.Run(commands,tableDriver);   
        }
    }
       
    
}
