/// ***************************************************************** 
/// File:        MainForm.cs 
/// Project:     CubeCompare-GUI 
/// Solution:    CubeCompare-Console
/// 
/// Author:      Fernando Arnez
/// Date:        2/13/2017
/// Description: The partial class file for MainForm.
/// ***************************************************************** 

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CubeCompare_GUI
{
    public partial class MainForm : Form
    {
        CubeConnectionUIUnit[] cubeConnections;
        const int numCubeConnections = 2;

        public MainForm()
        {
            InitializeComponent();

            this.Text = "Cube Compare File Editor";

            // Init variables
            cubeConnections = new CubeConnectionUIUnit[numCubeConnections];
            cubeConnections[0] = new CubeConnectionUIUnit();
            cubeConnections[1] = new CubeConnectionUIUnit();

            cubeConnections[0].DatasourceTextbox = Datasource1Textbox;
            cubeConnections[0].CatalogTextbox = Catalog1Textbox;
            cubeConnections[0].CubeTextbox = Cube1Textbox;
            cubeConnections[0].StartDatePicker = StartDate1DateTimePicker;
            cubeConnections[0].EndDatePicker = EndDate1DateTimePicker;

            cubeConnections[1].DatasourceTextbox = Datasource2Textbox;
            cubeConnections[1].CatalogTextbox = Catalog2Textbox;
            cubeConnections[1].CubeTextbox = Cube2Textbox;
            cubeConnections[1].StartDatePicker = StartDate2DateTimePicker;
            cubeConnections[1].EndDatePicker = EndDate2DateTimePicker;

            // Set components to default empty.
            clearDateTimePickers();
            clearAvailableListboxes();
        }

        #region Move Buttons
        private void MoveToQueryMeasuresButton_Click(object sender, EventArgs e)
        {
            foreach (string s in AvailableMeasuresListBox.SelectedItems)
            {
                if (!QueryMeasuresListBox.Items.Contains(s))
                    QueryMeasuresListBox.Items.Add(s);
            }
            foreach (string s in QueryMeasuresListBox.Items)
            {
                AvailableMeasuresListBox.Items.Remove(s);
            }
        }

        private void MoveToAvailableMeasuresButton_Click(object sender, EventArgs e)
        {
            foreach (string s in QueryMeasuresListBox.SelectedItems)
            {
                if (!AvailableMeasuresListBox.Items.Contains(s))
                    AvailableMeasuresListBox.Items.Add(s);
            }
            foreach (string s in AvailableMeasuresListBox.Items)
            {
                QueryMeasuresListBox.Items.Remove(s);
            }
        }

        private void MoveToQueryAttributesButton_Click(object sender, EventArgs e)
        {
            foreach (string s in AvailableAttributesListbox.SelectedItems)
            {
                if (!QueryAttributesListbox.Items.Contains(s))
                    QueryAttributesListbox.Items.Add(s);
            }
            foreach (string s in QueryAttributesListbox.Items)
            {
                AvailableAttributesListbox.Items.Remove(s);
            }
        }

        private void MoveToAvailableAttributesButton_Click(object sender, EventArgs e)
        {
            foreach (string s in QueryAttributesListbox.SelectedItems)
            {
                if (!AvailableAttributesListbox.Items.Contains(s))
                    AvailableAttributesListbox.Items.Add(s);
            }
            foreach (string s in AvailableAttributesListbox.Items)
            {
                QueryAttributesListbox.Items.Remove(s);
            }
        }

        private void MoveToQueryFiltersButton_Click(object sender, EventArgs e)
        {
            foreach (string s in AvailableFiltersListBox.SelectedItems)
            {
                if (!QueryFiltersListBox.Items.Contains(s))
                    QueryFiltersListBox.Items.Add(s);
            }
            foreach (string s in QueryFiltersListBox.Items)
            {
                AvailableFiltersListBox.Items.Remove(s);
            }
        }

        private void MoveToAvailableFiltersButton_Click(object sender, EventArgs e)
        {
            foreach (string s in QueryFiltersListBox.SelectedItems)
            {
                if (!AvailableFiltersListBox.Items.Contains(s))
                    AvailableFiltersListBox.Items.Add(s);
            }
            foreach (string s in AvailableFiltersListBox.Items)
            {
                QueryFiltersListBox.Items.Remove(s);
            }
        }
        #endregion

        #region DateTimePickers
        private void clearDateTimePickers()
        {
            StartDate1DateTimePicker.Checked = false;
            StartDate2DateTimePicker.Checked = false;
            EndDate1DateTimePicker.Checked = false;
            EndDate2DateTimePicker.Checked = false;

            StartDate1DateTimePicker.Format = DateTimePickerFormat.Custom;
            StartDate1DateTimePicker.CustomFormat = " ";

            StartDate2DateTimePicker.Format = DateTimePickerFormat.Custom;
            StartDate2DateTimePicker.CustomFormat = " ";

            EndDate1DateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDate1DateTimePicker.CustomFormat = " ";

            EndDate2DateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDate2DateTimePicker.CustomFormat = " ";

        }

        private void StartDate1DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDate1DateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void EndDate1DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDate1DateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void StartDate2DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDate2DateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void EndDate2DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDate2DateTimePicker.Format = DateTimePickerFormat.Short;
        }
        #endregion

        private void GetCubeInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> measureNames = CubeQueries.getAllMeasures(Datasource1Textbox.Text, Catalog1Textbox.Text, Cube1Textbox.Text);
                List<string> attributeNames = CubeQueries.getAllAttributes(Datasource1Textbox.Text, Catalog1Textbox.Text, Cube1Textbox.Text);
                List<string> searchFilters = CubeQueries.getVisibleHierarchiesByCube(Datasource1Textbox.Text, Catalog1Textbox.Text, Cube1Textbox.Text);

                clearAvailableListboxes();

                foreach (string s in measureNames)
                {
                    AvailableMeasuresListBox.Items.Add(s);
                }

                foreach (string s in attributeNames)
                {
                    AvailableAttributesListbox.Items.Add(s);
                }

                foreach (string s in searchFilters)
                {
                    SearchFiltersListBox.Items.Add(s);
                    DateAttributeCombobox.Items.Add(s);
                }

                
            }
            catch (ArgumentException ae)
            {
                if (ae.Message.Contains("A data source must be specified in the connection string."))
                {
                    MessageBox.Show("Empty connection information entered.\n"
                    + ae.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw ae;
                }
            }
            catch (Microsoft.AnalysisServices.AdomdClient.AdomdConnectionException ace)
            {
                if (ace.Message.Contains("A connection cannot be made."))
                {
                    MessageBox.Show("Unable to connect to server. Check your connection or connection information.\n"
                    + ace.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw ace;
                }
            }
            catch (Microsoft.AnalysisServices.AdomdClient.AdomdErrorResponseException aere)
            {
                if (aere.Message.Contains("Either the user,") &&
                    aere.Message.Contains("does not have access to the ") &&
                    aere.Message.Contains("database, or the database does not exist."))
                {
                    MessageBox.Show("Unable to connect to find catalog.\n"
                    + aere.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw aere;
                }
            }
        }

        private void clearAvailableListboxes()
        {
            AvailableMeasuresListBox.Items.Clear();
            AvailableAttributesListbox.Items.Clear();
            AvailableFiltersListBox.Items.Clear();
        }

        private void enableRunButton(string filepath)
        {
            FileToRunTextbox.Enabled = true; 
            FileToRunTextbox.Visible = true;
            FileToRunTextbox.Text = filepath;
            RunConsoleApplicationButton.Enabled = true;
            RunConsoleApplicationButton.Visible = true;
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            // Threshold validation
            double placeholder;
            if (!string.IsNullOrEmpty(MaximumDifferenceTextbox.Text) && 
                !double.TryParse(MaximumDifferenceTextbox.Text, out placeholder))
            {
                MessageBox.Show("Maximum Difference in incorrect format.\n",
                "Invalid input.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(MaximumPercentageTextbox.Text) && 
                !double.TryParse(MaximumPercentageTextbox.Text, out placeholder))
            {
                MessageBox.Show("Maximum Percentage in incorrect format.\n",
                "Invalid input.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            // Create and load a CubeCompareSettings
            CubeCompareSettings ccSettings = new CubeCompareSettings();

            List<string> measureNames = new List<string>();
            List<string> attributeNames = new List<string>();
            List<string> filterNames = new List<string>();

            // For connections
            // Setup date values first
            DateTime? dtsd1 = StartDate1DateTimePicker.Checked ? (DateTime?)StartDate1DateTimePicker.Value : null;
            DateTime? dted1 = EndDate1DateTimePicker.Checked ? (DateTime?)EndDate1DateTimePicker.Value : null;
            DateTime? dtsd2 = StartDate2DateTimePicker.Checked ? (DateTime?)StartDate2DateTimePicker.Value : null;
            DateTime? dted2 = EndDate2DateTimePicker.Checked ? (DateTime?)EndDate2DateTimePicker.Value : null;

            ccSettings.connections.Rows.Add(1, 
                Datasource1Textbox.Text,
                Catalog1Textbox.Text,
                Cube1Textbox.Text,
                dtsd1,
                dted1);
            ccSettings.connections.Rows.Add(2,
                Datasource2Textbox.Text,
                Catalog2Textbox.Text,
                Cube2Textbox.Text,
                dtsd2,
                dted2);

            // For measures
            foreach (object o in QueryMeasuresListBox.Items)
            {
                measureNames.Add(o.ToString());
            }

            ccSettings.addmeasures(measureNames);

            // For row labels
            foreach (object o in QueryAttributesListbox.Items)
            {
                attributeNames.Add(o.ToString());
            }

            ccSettings.addrowLabels(attributeNames);

            // For filters
            foreach (object o in QueryFiltersListBox.Items)
            {
                filterNames.Add(o.ToString());
            }

            ccSettings.addfilters(filterNames);

            // For thresholds, if blank, submit null.
            ccSettings.thresholds.Rows.Add(null,
                MaximumDifferenceTextbox.Text != "" ? MaximumDifferenceTextbox.Text : null,
                MaximumPercentageTextbox.Text != "" ? MaximumPercentageTextbox.Text : null);

            // For (other) settings
            ccSettings.settings.Rows.Add("Output Folder", OutputFolderTextbox.Text);
            ccSettings.settings.Rows.Add("Date Dimension", DateAttributeCombobox.Text);
            if (FilePerMeasureGroupCheckbox.Checked)
            {
                ccSettings.settings.Rows.Add("Excel file per measure group", "YES");
            }
            else
            {
                ccSettings.settings.Rows.Add("Excel file per measure group", "NO");
            }


            // Get file location and name then save to that filepath.
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ccSettings.saveTo(saveDialog.FileName);
                    // Enable to run from this file.
                    enableRunButton(saveDialog.FileName);
                }
            }

        }
    

       

        private void SearchFiltersButton_Click(object sender, EventArgs e)
        {
            // First clear the existing members
            AvailableFiltersListBox.Items.Clear();
            try
            {
                foreach (object o in SearchFiltersListBox.SelectedItems)
                {
                    List<string> members = CubeQueries.getMembersByHierarchy(o.ToString(), Datasource1Textbox.Text, Catalog1Textbox.Text, Cube1Textbox.Text);
                    foreach (string s in members)
                    {
                        AvailableFiltersListBox.Items.Add(s);
                    }
                }
            }
            catch (ArgumentException ae)
            {
                if (ae.Message.Contains("A data source must be specified in the connection string."))
                {
                    MessageBox.Show("Empty connection information entered.\n"
                    + ae.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw ae;
                }
            }
            catch (Microsoft.AnalysisServices.AdomdClient.AdomdConnectionException ace)
            {
                if (ace.Message.Contains("A connection cannot be made."))
                {
                    MessageBox.Show("Unable to connect to server. Check your connection or connection information.\n"
                    + ace.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw ace;
                }
            }
            catch (Microsoft.AnalysisServices.AdomdClient.AdomdErrorResponseException aere)
            {
                if (aere.Message.Contains("Either the user,") &&
                    aere.Message.Contains("does not have access to the ") &&
                    aere.Message.Contains("database, or the database does not exist."))
                {
                    MessageBox.Show("Unable to connect to find catalog.\n"
                    + aere.Message,
                    "Connection Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    throw aere;
                }
            }

        }

        private void BrowseOutputFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog browseDialog = new FolderBrowserDialog())
            {
                if (browseDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(browseDialog.SelectedPath))
                {
                    OutputFolderTextbox.Text = browseDialog.SelectedPath;
                }
            }
        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openDialog.FilterIndex = 1;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    clearDateTimePickers();
                    clearAvailableListboxes();
                    DateAttributeCombobox.Items.Clear();
                    try
                    {
                        CubeCompareSettings ccSettings = new CubeCompareSettings(openDialog.FileName);
                        

                        foreach (DataRow row in ccSettings.connections.Rows)
                        {
                            int rowOrder = Convert.ToInt32(row[0].ToString());
                            if (rowOrder > 0 && rowOrder <= cubeConnections.Length)
                            {
                                cubeConnections[rowOrder - 1].DatasourceTextbox.Text = row[1].ToString();
                                cubeConnections[rowOrder - 1].CatalogTextbox.Text = row[2].ToString();
                                cubeConnections[rowOrder - 1].CubeTextbox.Text = row[3].ToString();

                                if (row[4] != DBNull.Value)
                                {
                                    cubeConnections[rowOrder - 1].StartDatePicker.Checked = true;
                                    cubeConnections[rowOrder - 1].StartDatePicker.Format = DateTimePickerFormat.Short;
                                    cubeConnections[rowOrder - 1].StartDatePicker.Value = Convert.ToDateTime(row[4]);
                                }
                                if (row[5] != DBNull.Value)
                                {
                                    cubeConnections[rowOrder - 1].EndDatePicker.Checked = true;
                                    cubeConnections[rowOrder - 1].EndDatePicker.Format = DateTimePickerFormat.Short;
                                    cubeConnections[rowOrder - 1].EndDatePicker.Value = Convert.ToDateTime(row[5]);
                                }
                            }
                        }

                        // Measures
                        foreach (DataRow row in ccSettings.measures.Rows)
                        {
                            QueryMeasuresListBox.Items.Add(row[1].ToString());
                        }

                        // Attributes
                        foreach (DataRow row in ccSettings.rowLabels.Rows)
                        {
                            QueryAttributesListbox.Items.Add(row[1].ToString());
                        }
                        // Filters
                        foreach (DataRow row in ccSettings.filters.Rows)
                        {
                            QueryFiltersListBox.Items.Add(row[1].ToString());
                        }
                        // Thresholds
                        if (ccSettings.thresholds.Rows.Count > 0)
                        {
                            MaximumDifferenceTextbox.Text = ccSettings.thresholds.Rows[0][1].ToString();
                            MaximumPercentageTextbox.Text = ccSettings.thresholds.Rows[0][2].ToString();
                        }
                        // Other Settings
                        foreach (DataRow row in ccSettings.settings.Rows)
                        {
                            if (row[0].ToString() == "Output Folder")
                            {
                                OutputFolderTextbox.Text = row[1].ToString();
                            }
                            else if (row[0].ToString() == "Date Dimension")
                            {
                                DateAttributeCombobox.Items.Add(row[1].ToString());
                                DateAttributeCombobox.SelectedIndex = 0;
                            }
                            else if (row[0].ToString() == "Excel file per measure group")
                            {
                                if (row[1].ToString() == "YES")
                                {
                                    FilePerMeasureGroupCheckbox.Checked = true;
                                }
                                else if (row[1].ToString() == "NO")
                                {
                                    FilePerMeasureGroupCheckbox.Checked = false;
                                }
                            }
                        }

                        enableRunButton(openDialog.FileName);
                    }
                    catch (System.IO.IOException ex)
                    {
                        if (ex.Message.Contains("used by another process"))
                        {
                            MessageBox.Show("Unable to open file.\nThe following file is being used by another process: "
                                + openDialog.FileName + ".",
                                "Unable to open file.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("There isn't a worksheet named"))
                        {
                            MessageBox.Show("Error loading data from file.\n"
                            + ex.Message,
                            "Unable to read file.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("Missing table in spreadsheet"))
                        {
                            MessageBox.Show("Error loading data from file.\n"
                            + ex.Message,
                            "Unable to read file.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("Input in invalid format at"))
                        {
                            MessageBox.Show("Error loading data from file.\n"
                            + ex.Message,
                            "Unable to read file.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
            }
        }

        private void RunConsoleApplicationButton_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\CubeCompare-Console.exe"))
            {
                System.Diagnostics.Process.Start(@"cmd.exe", @"/k CubeCompare-Console.exe " + "\"" + FileToRunTextbox.Text + "\"");
            }
            else
            {
                MessageBox.Show("The CubeCompare console application cannot be found.\nExpecting:\n" +
                    System.IO.Directory.GetCurrentDirectory() + "\\CubeCompare-Console.exe",
                "Console application can not be found.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
