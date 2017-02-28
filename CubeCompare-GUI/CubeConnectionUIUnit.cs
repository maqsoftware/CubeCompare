/// ***************************************************************** 
/// File:        CubeQueries.cs 
/// Project:     CubeCompare-GUI 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: Contains the CubeConnectionUIUnit class, which is a
///              class to orginaize Connection UI parts into units.
/// ***************************************************************** 

using System.Windows.Forms;

namespace CubeCompare_GUI
{
    public class CubeConnectionUIUnit
    {
        public TextBox CatalogTextbox { get; set; }
        public TextBox CubeTextbox { get; set; }
        public TextBox DatasourceTextbox { get; set; }
        public DateTimePicker EndDatePicker { get; set; }
        public DateTimePicker StartDatePicker { get; set; }
    }
}