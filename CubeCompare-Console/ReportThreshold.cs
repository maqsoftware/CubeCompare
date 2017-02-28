/// ***************************************************************** 
/// File:        ReportThreshold.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains ReportThreshold class.
/// ***************************************************************** 
namespace CubeCompare_Console
{
    /// <summary>
    /// A ReportThreshold handles the threshold values and checks per row of a report whether the row exceeds the threshold.
    /// </summary>
    public class ReportThreshold
    {
        /// <summary>
        /// 
        /// </summary>
        public double MaxDifference { get; }

        /// <summary>
        /// 
        /// </summary>
        public double MaxPercentage { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDifference"></param>
        /// <param name="maxPercentage"></param>
        public ReportThreshold(double maxDifference, double maxPercentage)
        {
            this.MaxDifference = maxDifference;
            this.MaxPercentage = maxPercentage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="resultA"></param>
        /// <param name="resultB"></param>
        /// <param name="difference"></param>
        /// <param name="percentDifference"></param>
        /// <returns></returns>
        public bool doesDataPassThreshold(string label, double resultA, double resultB, double difference, double percentDifference)
        {
            return System.Math.Abs(difference) > MaxDifference || percentDifference > MaxPercentage;
        }
    }
}