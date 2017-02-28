/// ***************************************************************** 
/// File:        CubeQueryTimeRange.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeQueryTimeRange class.
/// ***************************************************************** 

using System;

namespace CubeCompare_Console
{

    /// <summary>
    /// Represents a time range for a query in date format.
    /// </summary>
    class CubeQueryTimeRange
    {
        /// <summary>
        /// get startdate
        /// </summary>
        public string StartDate { get; }

        /// <summary>
        /// gets EndDate
        /// </summary>
        public string EndDate { get; }

        /// <summary>
        /// Initialize StartDate and EndDate
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public CubeQueryTimeRange(DateTime startDate, DateTime endDate)
        {
            StartDate = convertDateTimeToMDXFormat(startDate);
            EndDate = convertDateTimeToMDXFormat(endDate);
        }

        // Must be in this format.
        //StartDate = "[2013-07-01T00:00:00]";
        //EndDate = "[2016-10-15T00:00:00]";

        /// <summary>
        /// convert date time to MDX format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string convertDateTimeToMDXFormat(DateTime date)
        {
            return (string.Format(Constants.dateYear, date.Year, prependZeroIfNeeded(date.Month), prependZeroIfNeeded(date.Day)));
        }

        /// <summary>
        /// Used to format a single digit number as double character string. Ex: 3 -> "03", 6 -> "06", and 11 -> "11". 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string prependZeroIfNeeded( int num)
        {
            if(num < 10)
                return  "0" + num.ToString();
            return num.ToString();
        }
    }
}
