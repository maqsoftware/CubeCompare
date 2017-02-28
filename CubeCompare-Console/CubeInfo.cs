/// ***************************************************************** 
/// File:        CubeInfo.cs 
/// Project:     CubeCompare-Console 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeInfo class.
/// ***************************************************************** 

namespace CubeCompare_Console
{
    /// <summary>
    /// Represents a data connection to a specific cube.
    /// </summary>
    class CubeInfo
    {
        /// <summary>
        /// Define cube metadata
        /// </summary>
        /// <param name="datasource">Server name</param>
        /// <param name="catalog">Database name</param>
        /// <param name="cube">Cube name</param>
        public CubeInfo(string dataSource, string catalog, string cube)
        {
            this.Datasource = dataSource;
            this.Catalog = catalog;
            this.Cube = cube;
        }

        /// <summary>
        /// gets datasource name
        /// </summary>
        public string Datasource { get;  }

        /// <summary>
        /// gets catalog name
        /// </summary>
        public string Catalog { get; }

        /// <summary>
        /// gets cube name
        /// </summary>
        public string Cube { get; }

        /// <summary>
        /// gets or sets time range for all queries to filter data
        /// </summary>
        public CubeQueryTimeRange TimeRange { get; private set; }

        /// <summary>
        /// gets or sets time dimension hierarchy
        /// </summary>
        public string TimeDimension { get; private set; } = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="timeDimension"></param>
        public void setTimeRange(CubeQueryTimeRange range, string timeDimension)
        {
            this.TimeDimension = timeDimension;
            this.TimeRange = range;
        }

        /// <summary>
        /// Create connection string for the cube using settings files data
        /// </summary>
        /// <returns></returns>
        public string getStandardConnectionString()
        {            
            return string.Format(Constants.dataSource,Datasource,Catalog); 
        }
    }
}
