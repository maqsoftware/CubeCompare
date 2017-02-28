/// ***************************************************************** 
/// File:        Program.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the Program class, and the main function 
///              which is the entry point of the program.
/// *****************************************************************

using System;
using System.Configuration;

namespace CubeCompare_Console
{
    /// <summary>
    /// The entry point of the program. Manipulates objects to create reports and handles exceptions from those objects.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string settingsFileLocation;

            // Set commandline mode based on arguments.
            if (args.Length == 0)
            {
                settingsFileLocation = ConfigurationManager.AppSettings[Constants.settingsLocation];
            }
            else
            {
                settingsFileLocation = args[0];
            }

            if (string.IsNullOrEmpty(settingsFileLocation))
            {
                Utility.WriteToConsole(Constants.missingSettings, 100);
                Console.Read();
                return;
            }

            Utility.WriteToConsole(string.Format(Constants.loadingReport, settingsFileLocation), 7);

            // Attempt to load settings file
            SettingsLoader settings = null;
            try
            {
                settings = new SettingsLoader(settingsFileLocation);
            }

            catch (System.IO.FileNotFoundException fnfe)
            {
                Utility.WriteToConsole(string.Format(Constants.settingFileNotFound, fnfe.Message), 100);
            }
            catch (System.IO.IOException ioe)
            {
                if (ioe.Message.Contains(Constants.usedByAnotherProcess))
                {
                    Utility.WriteToConsole(string.Format(Constants.additionalInfo, ioe.Message), 100);
                }
                else
                {
                    throw ioe;
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains(Constants.supportedExtension))
                {
                    Utility.WriteToConsole(string.Format(Constants.exception, e.Message), 100);
                }
                else
                {
                    Utility.WriteToConsole(string.Format(Constants.incorrectFormat, e.Message), 100);
                }
            }

            // Check if settings and connections are valid, if not, end program.
            if (settings == null)
            {
                Utility.WriteToConsole(Constants.failureLoading, 100);
                return;
            }
            Utility.WriteToConsole(Constants.validatingConnections, 1);
            if (settings.CubeComparison.validate() != 0)
            {
                Utility.WriteToConsole(Constants.failureValidatingConnections, 100);
                return;
            }

            // Run console application

            if (settings.Settings[Constants.excelFilePerMeasure] == Constants.yes)
            {
                settings.CubeComparison.queryReportsByAcquisitionGroup(settings.Settings[Constants.outputFolder]);
            }
            else
            {
                string fileName = string.Format(Constants.report, string.Join("-", DateTime.Now.ToString().Split(System.IO.Path.GetInvalidFileNameChars())));
                settings.CubeComparison.queryReportsToSpreadsheet(settings.Settings[Constants.outputFolder], fileName);
            }

        }   
    }
}
