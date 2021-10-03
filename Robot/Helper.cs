using System;
using System.IO;
using System.Reflection;
namespace Robot
{
    public static class Helper
    {
        public static string GetFolderPath(string currentPath)
        {
            var currentFolder = Directory.GetParent(currentPath);
            var projectFolderPath = "";
            while (currentFolder != null)
            {
                if (currentFolder.Name.Equals("bin"))
                {
                    projectFolderPath = currentFolder.Parent.FullName;
                    break;
                }
                currentFolder = currentFolder.Parent;
            }
            return projectFolderPath;
        }
        public static string[] GetCommands(string inputFile)
        {
            string projectFolderPath = GetFolderPath(Environment.CurrentDirectory);
            string inputFilePath = Path.Combine(projectFolderPath, inputFile);
            string[] commands = File.ReadAllLines(inputFilePath);
            return commands;
        }
    }
}
