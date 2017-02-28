/// ***************************************************************** 
/// File:        Report.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the Report class.
/// ***************************************************************** 
using System.Collections.Generic;

namespace CubeCompare_Console
{

    /// <summary>
    /// A report the neccessary information for a single report.
    /// </summary>
    class Report
    {
        /// <summary>
        /// 
        /// </summary>
        public CubeQueryTimeRange TimeRange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ReportNumber { get; }

        /// <summary>
        /// 
        /// </summary>
        public string MeasureUniqueName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string SliceByAttribute { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReportThreshold Threshold { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> FilterList { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportNumber"></param>
        /// <param name="measureUniqueName"></param>
        /// <param name="sliceByAttribute"></param>
        /// <param name="filterList"></param>
        /// <param name="reportThreshold"></param>
        public Report(int reportNumber, string measureUniqueName, string sliceByAttribute, List<string> filterList, ReportThreshold reportThreshold)
        {
            this.ReportNumber = reportNumber;
            this.MeasureUniqueName = measureUniqueName;
            this.SliceByAttribute = sliceByAttribute;
            this.FilterList = filterList;
            this.Threshold = reportThreshold;
        }
    }
}
