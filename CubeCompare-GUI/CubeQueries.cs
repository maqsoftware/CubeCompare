/// ***************************************************************** 
/// File:        CubeQueries.cs 
/// Project:     CubeCompare-GUI 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeQueries class which has functions which
///              queries a cube.
/// ***************************************************************** 

using System;
using System.Collections.Generic;
using Microsoft.AnalysisServices.AdomdClient;
using System.Data;

namespace CubeCompare_GUI
{
    class CubeQueries
    {
        static public List<string> getAllMeasures(string datasource, string catalog, string cube)
        {
            List<string> measureNames = new List<string>();

            string connectionString = string.Format(Constants.dataSource, datasource, catalog);

            using (AdomdConnection conn = new AdomdConnection(connectionString))
            {
                conn.Open();

                using (DataSet measures = conn.GetSchemaDataSet(Constants.mdSchema, null, true))
                {  
                    foreach (DataTable dta in measures.Tables)
                    {
                        foreach (DataRow dro in dta.Rows)
                        {
                            foreach (DataColumn dco in dta.Columns)
                            {
                                // Get non-null unique measure names
                                if (dro[dco] != null && dco.ColumnName.ToString() == Constants.measureUniqueName)
                                {
                                    measureNames.Add(dro[dco].ToString());
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }

            return measureNames;
        }

        public static List<string> getAllAttributes(string datasource, string catalog, string cube)
        {
            List<string> attributeNames = new List<string>();
            string connectionString = string.Format(Constants.dataSource, datasource, catalog); 

            using (AdomdConnection conn = new AdomdConnection(connectionString))
            {
                conn.Open();
                using (DataSet attributes = conn.GetSchemaDataSet(Constants.mdSchemaLevels, null, true))
                {
                    
                    foreach (DataTable dta in attributes.Tables)
                    {
                        foreach (DataRow dro in dta.Rows)
                        {
                            if (Convert.ToInt32((dro.ItemArray[9].ToString())) != 0) // Removes levels of type (All)
                            {
                                foreach (DataColumn dco in dta.Columns)
                                {
                                    // Get non-null unique names
                                    if (dro[dco] != null && dco.ColumnName.ToString() == Constants.levelUniqueName)
                                    {
                                        attributeNames.Add(dro[dco].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }
            return attributeNames;
        }

        public static List<string> getVisibleHierarchiesByCube(string datasource, string catalog, string cube)
        {
            List<string> hierarchies = new List<string>();

            string connectionString = string.Format(Constants.dataSource, datasource, catalog);

            AdomdRestrictionCollection restrictions = new AdomdRestrictionCollection();
            restrictions.Add(Constants.cubeName, cube);
            restrictions.Add(Constants.hierarchyVisibility, 1);

            using (AdomdConnection conn = new AdomdConnection(connectionString))
            {
                conn.Open();

                using (DataSet results = conn.GetSchemaDataSet(Constants.mdSchemaHierarchies, restrictions, true))
                {
                    foreach (DataTable dta in results.Tables)
                    {
                        foreach (DataRow dro in dta.Rows)
                        {
                            foreach (DataColumn dco in dta.Columns)
                            {
                                // Get non-null unique measure names
                                if (dro[dco] != null && dco.ColumnName.ToString() == Constants.hierarchyUniqueName)
                                {
                                    hierarchies.Add(dro[dco].ToString());
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }


            return hierarchies;
        }

        public static List<string> getMembersByHierarchy(string hierarchy, string datasource, string catalog, string cube)
        {
            List<String> members = new List<string>();

            string connectionString = string.Format(Constants.dataSource, datasource, catalog);

            AdomdRestrictionCollection restrictions = new AdomdRestrictionCollection();
            restrictions.Add(Constants.cubeName, cube);
            restrictions.Add(Constants.hierarchyUniqueName, hierarchy);

            using (AdomdConnection conn = new AdomdConnection(connectionString))
            {
                conn.Open();

                using (DataSet results = conn.GetSchemaDataSet(Constants.mdSchemaMembers, restrictions, true))
                {
                    foreach (DataTable dta in results.Tables)
                    {
                        foreach (DataRow dro in dta.Rows)
                        {
                            foreach (DataColumn dco in dta.Columns)
                            {
                                // Get non-null unique measure names
                                if (dro[dco] != null && dco.ColumnName.ToString() == Constants.memberUniqueName)
                                {
                                    members.Add(dro[dco].ToString());
                                }
                            }
                        }
                    }
                }
                conn.Close();
            }

            return members;
        }
    }
}
