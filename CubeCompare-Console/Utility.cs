/// ***************************************************************** 
/// File:        Utility.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains utility functions used by entire project.
/// ***************************************************************** 
using System;
using System.Linq;

namespace CubeCompare_Console
{
    class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static public string AddFiletofolderPath(string folderPath, string file)
        {
            if (folderPath.Last() == '\\')
                return folderPath + file;

            return folderPath + "\\" + file;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="type"></param>
        static public void WriteToConsole(string header, int type)
        {
            switch (type)
            {
                case 100:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(header);
                    Console.ResetColor();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("******************************************************");
                    Console.WriteLine(header);
                    Console.WriteLine("******************************************************");
                    Console.ResetColor();
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("******************************************************");
                    Console.WriteLine(header);
                    Console.WriteLine("******************************************************");
                    Console.ResetColor();
                    break;
                default:
                case 1:
                    Console.WriteLine(header);
                    break;
            }
        }
    }
}
