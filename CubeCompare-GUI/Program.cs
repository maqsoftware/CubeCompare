/// ***************************************************************** 
/// File:        Program.cs 
/// Project:     CubeCompare-GUI 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: The main entry point for the application.
/// ***************************************************************** 

using System;
using System.Windows.Forms;

namespace CubeCompare_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
