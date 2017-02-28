namespace CubeCompare_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AvailableMeasuresListBox = new System.Windows.Forms.ListBox();
            this.QueryMeasuresListBox = new System.Windows.Forms.ListBox();
            this.AvailableMeasuresLabel = new System.Windows.Forms.Label();
            this.QueryMeasuresLabel = new System.Windows.Forms.Label();
            this.MoveToQueryMeasuresButton = new System.Windows.Forms.Button();
            this.MoveToAvailableMeasuresButton = new System.Windows.Forms.Button();
            this.Datasource1Label = new System.Windows.Forms.Label();
            this.Datasource1Textbox = new System.Windows.Forms.TextBox();
            this.Catalog1Textbox = new System.Windows.Forms.TextBox();
            this.Catalog1Label = new System.Windows.Forms.Label();
            this.Cube1Textbox = new System.Windows.Forms.TextBox();
            this.Cube1Label = new System.Windows.Forms.Label();
            this.GetCubeInfoButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.MoveToAvailableAttributesButton = new System.Windows.Forms.Button();
            this.MoveToQueryAttributesButton = new System.Windows.Forms.Button();
            this.QueryAttributesLabel = new System.Windows.Forms.Label();
            this.AvailableAttributeLabel = new System.Windows.Forms.Label();
            this.QueryAttributesListbox = new System.Windows.Forms.ListBox();
            this.AvailableAttributesListbox = new System.Windows.Forms.ListBox();
            this.MoveToAvailableFiltersButton = new System.Windows.Forms.Button();
            this.MoveToQueryFiltersButton = new System.Windows.Forms.Button();
            this.QueryFiltersLabel = new System.Windows.Forms.Label();
            this.AvailableFiltersLabel = new System.Windows.Forms.Label();
            this.QueryFiltersListBox = new System.Windows.Forms.ListBox();
            this.AvailableFiltersListBox = new System.Windows.Forms.ListBox();
            this.SearchFiltersListBox = new System.Windows.Forms.ListBox();
            this.Cube1InfoLabel = new System.Windows.Forms.Label();
            this.Cube2InfoLabel = new System.Windows.Forms.Label();
            this.Cube2Textbox = new System.Windows.Forms.TextBox();
            this.Cube2Label = new System.Windows.Forms.Label();
            this.Catalog2Textbox = new System.Windows.Forms.TextBox();
            this.Catalog2Label = new System.Windows.Forms.Label();
            this.Datasource2Textbox = new System.Windows.Forms.TextBox();
            this.Datasource2Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchFiltersButton = new System.Windows.Forms.Button();
            this.SummaryThresholdsLabel = new System.Windows.Forms.Label();
            this.MaximumPercentageTextbox = new System.Windows.Forms.TextBox();
            this.MaximumPercentageLabel = new System.Windows.Forms.Label();
            this.MaximumDifferenceTextbox = new System.Windows.Forms.TextBox();
            this.MaximumDifferenceLabel = new System.Windows.Forms.Label();
            this.OtherSettingsLabel = new System.Windows.Forms.Label();
            this.DateDimensionLabel = new System.Windows.Forms.Label();
            this.OutputFolderTextbox = new System.Windows.Forms.TextBox();
            this.OutputFolderLabel = new System.Windows.Forms.Label();
            this.FilePerMeasureGroupCheckbox = new System.Windows.Forms.CheckBox();
            this.BrowseOutputFolderButton = new System.Windows.Forms.Button();
            this.StartDate1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDate1Label = new System.Windows.Forms.Label();
            this.EndDate1Label = new System.Windows.Forms.Label();
            this.EndDate1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDate2Label = new System.Windows.Forms.Label();
            this.EndDate2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDate2Label = new System.Windows.Forms.Label();
            this.StartDate2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LoadFromFileButton = new System.Windows.Forms.Button();
            this.DateAttributeCombobox = new System.Windows.Forms.ComboBox();
            this.FileToRunTextbox = new System.Windows.Forms.TextBox();
            this.RunConsoleApplicationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AvailableMeasuresListBox
            // 
            this.AvailableMeasuresListBox.FormattingEnabled = true;
            this.AvailableMeasuresListBox.HorizontalScrollbar = true;
            this.AvailableMeasuresListBox.ItemHeight = 20;
            this.AvailableMeasuresListBox.Location = new System.Drawing.Point(766, 45);
            this.AvailableMeasuresListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailableMeasuresListBox.Name = "AvailableMeasuresListBox";
            this.AvailableMeasuresListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AvailableMeasuresListBox.Size = new System.Drawing.Size(378, 204);
            this.AvailableMeasuresListBox.TabIndex = 0;
            // 
            // QueryMeasuresListBox
            // 
            this.QueryMeasuresListBox.AllowDrop = true;
            this.QueryMeasuresListBox.FormattingEnabled = true;
            this.QueryMeasuresListBox.HorizontalScrollbar = true;
            this.QueryMeasuresListBox.ItemHeight = 20;
            this.QueryMeasuresListBox.Location = new System.Drawing.Point(1209, 45);
            this.QueryMeasuresListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueryMeasuresListBox.Name = "QueryMeasuresListBox";
            this.QueryMeasuresListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.QueryMeasuresListBox.Size = new System.Drawing.Size(378, 204);
            this.QueryMeasuresListBox.TabIndex = 1;
            // 
            // AvailableMeasuresLabel
            // 
            this.AvailableMeasuresLabel.AutoSize = true;
            this.AvailableMeasuresLabel.Location = new System.Drawing.Point(762, 15);
            this.AvailableMeasuresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailableMeasuresLabel.Name = "AvailableMeasuresLabel";
            this.AvailableMeasuresLabel.Size = new System.Drawing.Size(146, 20);
            this.AvailableMeasuresLabel.TabIndex = 2;
            this.AvailableMeasuresLabel.Text = "Available Measures";
            // 
            // QueryMeasuresLabel
            // 
            this.QueryMeasuresLabel.AutoSize = true;
            this.QueryMeasuresLabel.Location = new System.Drawing.Point(1204, 15);
            this.QueryMeasuresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QueryMeasuresLabel.Name = "QueryMeasuresLabel";
            this.QueryMeasuresLabel.Size = new System.Drawing.Size(143, 20);
            this.QueryMeasuresLabel.TabIndex = 3;
            this.QueryMeasuresLabel.Text = "Measures to Query";
            // 
            // MoveToQueryMeasuresButton
            // 
            this.MoveToQueryMeasuresButton.Location = new System.Drawing.Point(1155, 98);
            this.MoveToQueryMeasuresButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToQueryMeasuresButton.Name = "MoveToQueryMeasuresButton";
            this.MoveToQueryMeasuresButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToQueryMeasuresButton.TabIndex = 4;
            this.MoveToQueryMeasuresButton.Text = ">>";
            this.MoveToQueryMeasuresButton.UseVisualStyleBackColor = true;
            this.MoveToQueryMeasuresButton.Click += new System.EventHandler(this.MoveToQueryMeasuresButton_Click);
            // 
            // MoveToAvailableMeasuresButton
            // 
            this.MoveToAvailableMeasuresButton.Location = new System.Drawing.Point(1155, 151);
            this.MoveToAvailableMeasuresButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToAvailableMeasuresButton.Name = "MoveToAvailableMeasuresButton";
            this.MoveToAvailableMeasuresButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToAvailableMeasuresButton.TabIndex = 5;
            this.MoveToAvailableMeasuresButton.Text = "<<";
            this.MoveToAvailableMeasuresButton.UseVisualStyleBackColor = true;
            this.MoveToAvailableMeasuresButton.Click += new System.EventHandler(this.MoveToAvailableMeasuresButton_Click);
            // 
            // Datasource1Label
            // 
            this.Datasource1Label.AutoSize = true;
            this.Datasource1Label.Location = new System.Drawing.Point(44, 65);
            this.Datasource1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Datasource1Label.Name = "Datasource1Label";
            this.Datasource1Label.Size = new System.Drawing.Size(92, 20);
            this.Datasource1Label.TabIndex = 6;
            this.Datasource1Label.Text = "Datasource";
            // 
            // Datasource1Textbox
            // 
            this.Datasource1Textbox.AllowDrop = true;
            this.Datasource1Textbox.Location = new System.Drawing.Point(48, 89);
            this.Datasource1Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Datasource1Textbox.Name = "Datasource1Textbox";
            this.Datasource1Textbox.Size = new System.Drawing.Size(196, 26);
            this.Datasource1Textbox.TabIndex = 7;
            // 
            // Catalog1Textbox
            // 
            this.Catalog1Textbox.AllowDrop = true;
            this.Catalog1Textbox.Location = new System.Drawing.Point(48, 152);
            this.Catalog1Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Catalog1Textbox.Name = "Catalog1Textbox";
            this.Catalog1Textbox.Size = new System.Drawing.Size(196, 26);
            this.Catalog1Textbox.TabIndex = 9;
            // 
            // Catalog1Label
            // 
            this.Catalog1Label.AutoSize = true;
            this.Catalog1Label.Location = new System.Drawing.Point(44, 128);
            this.Catalog1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Catalog1Label.Name = "Catalog1Label";
            this.Catalog1Label.Size = new System.Drawing.Size(64, 20);
            this.Catalog1Label.TabIndex = 8;
            this.Catalog1Label.Text = "Catalog";
            // 
            // Cube1Textbox
            // 
            this.Cube1Textbox.AllowDrop = true;
            this.Cube1Textbox.Location = new System.Drawing.Point(48, 220);
            this.Cube1Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cube1Textbox.Name = "Cube1Textbox";
            this.Cube1Textbox.Size = new System.Drawing.Size(196, 26);
            this.Cube1Textbox.TabIndex = 11;
            // 
            // Cube1Label
            // 
            this.Cube1Label.AutoSize = true;
            this.Cube1Label.Location = new System.Drawing.Point(44, 195);
            this.Cube1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cube1Label.Name = "Cube1Label";
            this.Cube1Label.Size = new System.Drawing.Size(47, 20);
            this.Cube1Label.TabIndex = 10;
            this.Cube1Label.Text = "Cube";
            // 
            // GetCubeInfoButton
            // 
            this.GetCubeInfoButton.Location = new System.Drawing.Point(766, 768);
            this.GetCubeInfoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetCubeInfoButton.Name = "GetCubeInfoButton";
            this.GetCubeInfoButton.Size = new System.Drawing.Size(198, 35);
            this.GetCubeInfoButton.TabIndex = 12;
            this.GetCubeInfoButton.Text = "Get Cube Info (Cube 1)";
            this.GetCubeInfoButton.UseVisualStyleBackColor = true;
            this.GetCubeInfoButton.Click += new System.EventHandler(this.GetCubeInfoButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Location = new System.Drawing.Point(1017, 766);
            this.SaveAsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(129, 35);
            this.SaveAsButton.TabIndex = 13;
            this.SaveAsButton.Text = "Save As";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // MoveToAvailableAttributesButton
            // 
            this.MoveToAvailableAttributesButton.Location = new System.Drawing.Point(1155, 395);
            this.MoveToAvailableAttributesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToAvailableAttributesButton.Name = "MoveToAvailableAttributesButton";
            this.MoveToAvailableAttributesButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToAvailableAttributesButton.TabIndex = 19;
            this.MoveToAvailableAttributesButton.Text = "<<";
            this.MoveToAvailableAttributesButton.UseVisualStyleBackColor = true;
            this.MoveToAvailableAttributesButton.Click += new System.EventHandler(this.MoveToAvailableAttributesButton_Click);
            // 
            // MoveToQueryAttributesButton
            // 
            this.MoveToQueryAttributesButton.Location = new System.Drawing.Point(1155, 343);
            this.MoveToQueryAttributesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToQueryAttributesButton.Name = "MoveToQueryAttributesButton";
            this.MoveToQueryAttributesButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToQueryAttributesButton.TabIndex = 18;
            this.MoveToQueryAttributesButton.Text = ">>";
            this.MoveToQueryAttributesButton.UseVisualStyleBackColor = true;
            this.MoveToQueryAttributesButton.Click += new System.EventHandler(this.MoveToQueryAttributesButton_Click);
            // 
            // QueryAttributesLabel
            // 
            this.QueryAttributesLabel.AutoSize = true;
            this.QueryAttributesLabel.Location = new System.Drawing.Point(1204, 260);
            this.QueryAttributesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QueryAttributesLabel.Name = "QueryAttributesLabel";
            this.QueryAttributesLabel.Size = new System.Drawing.Size(142, 20);
            this.QueryAttributesLabel.TabIndex = 17;
            this.QueryAttributesLabel.Text = "Attributes to Query";
            // 
            // AvailableAttributeLabel
            // 
            this.AvailableAttributeLabel.AutoSize = true;
            this.AvailableAttributeLabel.Location = new System.Drawing.Point(762, 260);
            this.AvailableAttributeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailableAttributeLabel.Name = "AvailableAttributeLabel";
            this.AvailableAttributeLabel.Size = new System.Drawing.Size(145, 20);
            this.AvailableAttributeLabel.TabIndex = 16;
            this.AvailableAttributeLabel.Text = "Available Attributes";
            // 
            // QueryAttributesListbox
            // 
            this.QueryAttributesListbox.AllowDrop = true;
            this.QueryAttributesListbox.FormattingEnabled = true;
            this.QueryAttributesListbox.HorizontalScrollbar = true;
            this.QueryAttributesListbox.ItemHeight = 20;
            this.QueryAttributesListbox.Location = new System.Drawing.Point(1209, 289);
            this.QueryAttributesListbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueryAttributesListbox.Name = "QueryAttributesListbox";
            this.QueryAttributesListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.QueryAttributesListbox.Size = new System.Drawing.Size(378, 204);
            this.QueryAttributesListbox.TabIndex = 15;
            // 
            // AvailableAttributesListbox
            // 
            this.AvailableAttributesListbox.FormattingEnabled = true;
            this.AvailableAttributesListbox.HorizontalScrollbar = true;
            this.AvailableAttributesListbox.ItemHeight = 20;
            this.AvailableAttributesListbox.Location = new System.Drawing.Point(766, 289);
            this.AvailableAttributesListbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailableAttributesListbox.Name = "AvailableAttributesListbox";
            this.AvailableAttributesListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AvailableAttributesListbox.Size = new System.Drawing.Size(378, 204);
            this.AvailableAttributesListbox.TabIndex = 14;
            // 
            // MoveToAvailableFiltersButton
            // 
            this.MoveToAvailableFiltersButton.Location = new System.Drawing.Point(1155, 642);
            this.MoveToAvailableFiltersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToAvailableFiltersButton.Name = "MoveToAvailableFiltersButton";
            this.MoveToAvailableFiltersButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToAvailableFiltersButton.TabIndex = 25;
            this.MoveToAvailableFiltersButton.Text = "<<";
            this.MoveToAvailableFiltersButton.UseVisualStyleBackColor = true;
            this.MoveToAvailableFiltersButton.Click += new System.EventHandler(this.MoveToAvailableFiltersButton_Click);
            // 
            // MoveToQueryFiltersButton
            // 
            this.MoveToQueryFiltersButton.Location = new System.Drawing.Point(1155, 589);
            this.MoveToQueryFiltersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToQueryFiltersButton.Name = "MoveToQueryFiltersButton";
            this.MoveToQueryFiltersButton.Size = new System.Drawing.Size(45, 43);
            this.MoveToQueryFiltersButton.TabIndex = 24;
            this.MoveToQueryFiltersButton.Text = ">>";
            this.MoveToQueryFiltersButton.UseVisualStyleBackColor = true;
            this.MoveToQueryFiltersButton.Click += new System.EventHandler(this.MoveToQueryFiltersButton_Click);
            // 
            // QueryFiltersLabel
            // 
            this.QueryFiltersLabel.AutoSize = true;
            this.QueryFiltersLabel.Location = new System.Drawing.Point(1204, 506);
            this.QueryFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QueryFiltersLabel.Name = "QueryFiltersLabel";
            this.QueryFiltersLabel.Size = new System.Drawing.Size(136, 20);
            this.QueryFiltersLabel.TabIndex = 23;
            this.QueryFiltersLabel.Text = "Filters to Query by";
            // 
            // AvailableFiltersLabel
            // 
            this.AvailableFiltersLabel.AutoSize = true;
            this.AvailableFiltersLabel.Location = new System.Drawing.Point(762, 506);
            this.AvailableFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailableFiltersLabel.Name = "AvailableFiltersLabel";
            this.AvailableFiltersLabel.Size = new System.Drawing.Size(119, 20);
            this.AvailableFiltersLabel.TabIndex = 22;
            this.AvailableFiltersLabel.Text = "Available Filters";
            // 
            // QueryFiltersListBox
            // 
            this.QueryFiltersListBox.AllowDrop = true;
            this.QueryFiltersListBox.FormattingEnabled = true;
            this.QueryFiltersListBox.HorizontalScrollbar = true;
            this.QueryFiltersListBox.ItemHeight = 20;
            this.QueryFiltersListBox.Location = new System.Drawing.Point(1209, 535);
            this.QueryFiltersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueryFiltersListBox.Name = "QueryFiltersListBox";
            this.QueryFiltersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.QueryFiltersListBox.Size = new System.Drawing.Size(378, 204);
            this.QueryFiltersListBox.TabIndex = 21;
            // 
            // AvailableFiltersListBox
            // 
            this.AvailableFiltersListBox.FormattingEnabled = true;
            this.AvailableFiltersListBox.HorizontalScrollbar = true;
            this.AvailableFiltersListBox.ItemHeight = 20;
            this.AvailableFiltersListBox.Location = new System.Drawing.Point(766, 535);
            this.AvailableFiltersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailableFiltersListBox.Name = "AvailableFiltersListBox";
            this.AvailableFiltersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AvailableFiltersListBox.Size = new System.Drawing.Size(378, 204);
            this.AvailableFiltersListBox.TabIndex = 20;
            // 
            // SearchFiltersListBox
            // 
            this.SearchFiltersListBox.FormattingEnabled = true;
            this.SearchFiltersListBox.HorizontalScrollbar = true;
            this.SearchFiltersListBox.ItemHeight = 20;
            this.SearchFiltersListBox.Location = new System.Drawing.Point(327, 535);
            this.SearchFiltersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchFiltersListBox.Name = "SearchFiltersListBox";
            this.SearchFiltersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SearchFiltersListBox.Size = new System.Drawing.Size(378, 204);
            this.SearchFiltersListBox.TabIndex = 26;
            // 
            // Cube1InfoLabel
            // 
            this.Cube1InfoLabel.AutoSize = true;
            this.Cube1InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cube1InfoLabel.Location = new System.Drawing.Point(36, 34);
            this.Cube1InfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cube1InfoLabel.Name = "Cube1InfoLabel";
            this.Cube1InfoLabel.Size = new System.Drawing.Size(163, 20);
            this.Cube1InfoLabel.TabIndex = 27;
            this.Cube1InfoLabel.Text = "Cube 1 Information";
            // 
            // Cube2InfoLabel
            // 
            this.Cube2InfoLabel.AutoSize = true;
            this.Cube2InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cube2InfoLabel.Location = new System.Drawing.Point(388, 34);
            this.Cube2InfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cube2InfoLabel.Name = "Cube2InfoLabel";
            this.Cube2InfoLabel.Size = new System.Drawing.Size(163, 20);
            this.Cube2InfoLabel.TabIndex = 28;
            this.Cube2InfoLabel.Text = "Cube 2 Information";
            // 
            // Cube2Textbox
            // 
            this.Cube2Textbox.AllowDrop = true;
            this.Cube2Textbox.Location = new System.Drawing.Point(400, 223);
            this.Cube2Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cube2Textbox.Name = "Cube2Textbox";
            this.Cube2Textbox.Size = new System.Drawing.Size(196, 26);
            this.Cube2Textbox.TabIndex = 34;
            // 
            // Cube2Label
            // 
            this.Cube2Label.AutoSize = true;
            this.Cube2Label.Location = new System.Drawing.Point(396, 198);
            this.Cube2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cube2Label.Name = "Cube2Label";
            this.Cube2Label.Size = new System.Drawing.Size(47, 20);
            this.Cube2Label.TabIndex = 33;
            this.Cube2Label.Text = "Cube";
            // 
            // Catalog2Textbox
            // 
            this.Catalog2Textbox.AllowDrop = true;
            this.Catalog2Textbox.Location = new System.Drawing.Point(400, 152);
            this.Catalog2Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Catalog2Textbox.Name = "Catalog2Textbox";
            this.Catalog2Textbox.Size = new System.Drawing.Size(196, 26);
            this.Catalog2Textbox.TabIndex = 32;
            // 
            // Catalog2Label
            // 
            this.Catalog2Label.AutoSize = true;
            this.Catalog2Label.Location = new System.Drawing.Point(396, 128);
            this.Catalog2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Catalog2Label.Name = "Catalog2Label";
            this.Catalog2Label.Size = new System.Drawing.Size(64, 20);
            this.Catalog2Label.TabIndex = 31;
            this.Catalog2Label.Text = "Catalog";
            // 
            // Datasource2Textbox
            // 
            this.Datasource2Textbox.AllowDrop = true;
            this.Datasource2Textbox.Location = new System.Drawing.Point(400, 89);
            this.Datasource2Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Datasource2Textbox.Name = "Datasource2Textbox";
            this.Datasource2Textbox.Size = new System.Drawing.Size(196, 26);
            this.Datasource2Textbox.TabIndex = 30;
            // 
            // Datasource2Label
            // 
            this.Datasource2Label.AutoSize = true;
            this.Datasource2Label.Location = new System.Drawing.Point(396, 65);
            this.Datasource2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Datasource2Label.Name = "Datasource2Label";
            this.Datasource2Label.Size = new System.Drawing.Size(92, 20);
            this.Datasource2Label.TabIndex = 29;
            this.Datasource2Label.Text = "Datasource";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 506);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Search for filters";
            // 
            // SearchFiltersButton
            // 
            this.SearchFiltersButton.Location = new System.Drawing.Point(327, 751);
            this.SearchFiltersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchFiltersButton.Name = "SearchFiltersButton";
            this.SearchFiltersButton.Size = new System.Drawing.Size(380, 52);
            this.SearchFiltersButton.TabIndex = 36;
            this.SearchFiltersButton.Text = "Search by selection";
            this.SearchFiltersButton.UseVisualStyleBackColor = true;
            this.SearchFiltersButton.Click += new System.EventHandler(this.SearchFiltersButton_Click);
            // 
            // SummaryThresholdsLabel
            // 
            this.SummaryThresholdsLabel.AutoSize = true;
            this.SummaryThresholdsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryThresholdsLabel.Location = new System.Drawing.Point(36, 429);
            this.SummaryThresholdsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SummaryThresholdsLabel.Name = "SummaryThresholdsLabel";
            this.SummaryThresholdsLabel.Size = new System.Drawing.Size(176, 20);
            this.SummaryThresholdsLabel.TabIndex = 41;
            this.SummaryThresholdsLabel.Text = "Summary Thresholds";
            // 
            // MaximumPercentageTextbox
            // 
            this.MaximumPercentageTextbox.AllowDrop = true;
            this.MaximumPercentageTextbox.Location = new System.Drawing.Point(48, 548);
            this.MaximumPercentageTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumPercentageTextbox.Name = "MaximumPercentageTextbox";
            this.MaximumPercentageTextbox.Size = new System.Drawing.Size(196, 26);
            this.MaximumPercentageTextbox.TabIndex = 40;
            // 
            // MaximumPercentageLabel
            // 
            this.MaximumPercentageLabel.AutoSize = true;
            this.MaximumPercentageLabel.Location = new System.Drawing.Point(44, 520);
            this.MaximumPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaximumPercentageLabel.Name = "MaximumPercentageLabel";
            this.MaximumPercentageLabel.Size = new System.Drawing.Size(233, 20);
            this.MaximumPercentageLabel.TabIndex = 39;
            this.MaximumPercentageLabel.Text = "Maximum Percentage (Decimal)";
            // 
            // MaximumDifferenceTextbox
            // 
            this.MaximumDifferenceTextbox.AllowDrop = true;
            this.MaximumDifferenceTextbox.Location = new System.Drawing.Point(48, 485);
            this.MaximumDifferenceTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumDifferenceTextbox.Name = "MaximumDifferenceTextbox";
            this.MaximumDifferenceTextbox.Size = new System.Drawing.Size(196, 26);
            this.MaximumDifferenceTextbox.TabIndex = 38;
            // 
            // MaximumDifferenceLabel
            // 
            this.MaximumDifferenceLabel.AutoSize = true;
            this.MaximumDifferenceLabel.Location = new System.Drawing.Point(44, 460);
            this.MaximumDifferenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaximumDifferenceLabel.Name = "MaximumDifferenceLabel";
            this.MaximumDifferenceLabel.Size = new System.Drawing.Size(154, 20);
            this.MaximumDifferenceLabel.TabIndex = 37;
            this.MaximumDifferenceLabel.Text = "Maximum Difference";
            // 
            // OtherSettingsLabel
            // 
            this.OtherSettingsLabel.AutoSize = true;
            this.OtherSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherSettingsLabel.Location = new System.Drawing.Point(36, 605);
            this.OtherSettingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OtherSettingsLabel.Name = "OtherSettingsLabel";
            this.OtherSettingsLabel.Size = new System.Drawing.Size(126, 20);
            this.OtherSettingsLabel.TabIndex = 46;
            this.OtherSettingsLabel.Text = "Other Settings";
            // 
            // DateDimensionLabel
            // 
            this.DateDimensionLabel.AutoSize = true;
            this.DateDimensionLabel.Location = new System.Drawing.Point(44, 740);
            this.DateDimensionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DateDimensionLabel.Name = "DateDimensionLabel";
            this.DateDimensionLabel.Size = new System.Drawing.Size(220, 20);
            this.DateDimensionLabel.TabIndex = 44;
            this.DateDimensionLabel.Text = "Date Attribute (Unique Name)";
            // 
            // OutputFolderTextbox
            // 
            this.OutputFolderTextbox.AllowDrop = true;
            this.OutputFolderTextbox.Location = new System.Drawing.Point(48, 660);
            this.OutputFolderTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OutputFolderTextbox.Name = "OutputFolderTextbox";
            this.OutputFolderTextbox.Size = new System.Drawing.Size(196, 26);
            this.OutputFolderTextbox.TabIndex = 43;
            // 
            // OutputFolderLabel
            // 
            this.OutputFolderLabel.AutoSize = true;
            this.OutputFolderLabel.Location = new System.Drawing.Point(44, 635);
            this.OutputFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OutputFolderLabel.Name = "OutputFolderLabel";
            this.OutputFolderLabel.Size = new System.Drawing.Size(107, 20);
            this.OutputFolderLabel.TabIndex = 42;
            this.OutputFolderLabel.Text = "Output Folder";
            // 
            // FilePerMeasureGroupCheckbox
            // 
            this.FilePerMeasureGroupCheckbox.AutoSize = true;
            this.FilePerMeasureGroupCheckbox.Location = new System.Drawing.Point(48, 808);
            this.FilePerMeasureGroupCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilePerMeasureGroupCheckbox.Name = "FilePerMeasureGroupCheckbox";
            this.FilePerMeasureGroupCheckbox.Size = new System.Drawing.Size(228, 24);
            this.FilePerMeasureGroupCheckbox.TabIndex = 47;
            this.FilePerMeasureGroupCheckbox.Text = "Excel file per measure group";
            this.FilePerMeasureGroupCheckbox.UseVisualStyleBackColor = true;
            // 
            // BrowseOutputFolderButton
            // 
            this.BrowseOutputFolderButton.Location = new System.Drawing.Point(48, 700);
            this.BrowseOutputFolderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BrowseOutputFolderButton.Name = "BrowseOutputFolderButton";
            this.BrowseOutputFolderButton.Size = new System.Drawing.Size(198, 35);
            this.BrowseOutputFolderButton.TabIndex = 48;
            this.BrowseOutputFolderButton.Text = "Browse for Output Folder";
            this.BrowseOutputFolderButton.UseVisualStyleBackColor = true;
            this.BrowseOutputFolderButton.Click += new System.EventHandler(this.BrowseOutputFolderButton_Click);
            // 
            // StartDate1DateTimePicker
            // 
            this.StartDate1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate1DateTimePicker.Location = new System.Drawing.Point(48, 289);
            this.StartDate1DateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartDate1DateTimePicker.Name = "StartDate1DateTimePicker";
            this.StartDate1DateTimePicker.Size = new System.Drawing.Size(196, 26);
            this.StartDate1DateTimePicker.TabIndex = 49;
            this.StartDate1DateTimePicker.ValueChanged += new System.EventHandler(this.StartDate1DateTimePicker_ValueChanged);
            // 
            // StartDate1Label
            // 
            this.StartDate1Label.AutoSize = true;
            this.StartDate1Label.Location = new System.Drawing.Point(44, 260);
            this.StartDate1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartDate1Label.Name = "StartDate1Label";
            this.StartDate1Label.Size = new System.Drawing.Size(83, 20);
            this.StartDate1Label.TabIndex = 50;
            this.StartDate1Label.Text = "Start Date";
            // 
            // EndDate1Label
            // 
            this.EndDate1Label.AutoSize = true;
            this.EndDate1Label.Location = new System.Drawing.Point(44, 325);
            this.EndDate1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndDate1Label.Name = "EndDate1Label";
            this.EndDate1Label.Size = new System.Drawing.Size(77, 20);
            this.EndDate1Label.TabIndex = 52;
            this.EndDate1Label.Text = "End Date";
            // 
            // EndDate1DateTimePicker
            // 
            this.EndDate1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate1DateTimePicker.Location = new System.Drawing.Point(48, 354);
            this.EndDate1DateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndDate1DateTimePicker.Name = "EndDate1DateTimePicker";
            this.EndDate1DateTimePicker.Size = new System.Drawing.Size(196, 26);
            this.EndDate1DateTimePicker.TabIndex = 51;
            this.EndDate1DateTimePicker.ValueChanged += new System.EventHandler(this.EndDate1DateTimePicker_ValueChanged);
            // 
            // EndDate2Label
            // 
            this.EndDate2Label.AutoSize = true;
            this.EndDate2Label.Location = new System.Drawing.Point(396, 325);
            this.EndDate2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndDate2Label.Name = "EndDate2Label";
            this.EndDate2Label.Size = new System.Drawing.Size(77, 20);
            this.EndDate2Label.TabIndex = 56;
            this.EndDate2Label.Text = "End Date";
            // 
            // EndDate2DateTimePicker
            // 
            this.EndDate2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate2DateTimePicker.Location = new System.Drawing.Point(400, 354);
            this.EndDate2DateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndDate2DateTimePicker.Name = "EndDate2DateTimePicker";
            this.EndDate2DateTimePicker.Size = new System.Drawing.Size(196, 26);
            this.EndDate2DateTimePicker.TabIndex = 55;
            this.EndDate2DateTimePicker.ValueChanged += new System.EventHandler(this.EndDate2DateTimePicker_ValueChanged);
            // 
            // StartDate2Label
            // 
            this.StartDate2Label.AutoSize = true;
            this.StartDate2Label.Location = new System.Drawing.Point(396, 260);
            this.StartDate2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartDate2Label.Name = "StartDate2Label";
            this.StartDate2Label.Size = new System.Drawing.Size(83, 20);
            this.StartDate2Label.TabIndex = 54;
            this.StartDate2Label.Text = "Start Date";
            // 
            // StartDate2DateTimePicker
            // 
            this.StartDate2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate2DateTimePicker.Location = new System.Drawing.Point(400, 289);
            this.StartDate2DateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartDate2DateTimePicker.Name = "StartDate2DateTimePicker";
            this.StartDate2DateTimePicker.Size = new System.Drawing.Size(196, 26);
            this.StartDate2DateTimePicker.TabIndex = 53;
            this.StartDate2DateTimePicker.ValueChanged += new System.EventHandler(this.StartDate2DateTimePicker_ValueChanged);
            // 
            // LoadFromFileButton
            // 
            this.LoadFromFileButton.Location = new System.Drawing.Point(1017, 811);
            this.LoadFromFileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoadFromFileButton.Name = "LoadFromFileButton";
            this.LoadFromFileButton.Size = new System.Drawing.Size(129, 35);
            this.LoadFromFileButton.TabIndex = 57;
            this.LoadFromFileButton.Text = "Load From File";
            this.LoadFromFileButton.UseVisualStyleBackColor = true;
            this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
            // 
            // DateAttributeCombobox
            // 
            this.DateAttributeCombobox.AllowDrop = true;
            this.DateAttributeCombobox.FormattingEnabled = true;
            this.DateAttributeCombobox.Location = new System.Drawing.Point(48, 766);
            this.DateAttributeCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DateAttributeCombobox.Name = "DateAttributeCombobox";
            this.DateAttributeCombobox.Size = new System.Drawing.Size(196, 28);
            this.DateAttributeCombobox.TabIndex = 58;
            // 
            // FileToRunTextbox
            // 
            this.FileToRunTextbox.Enabled = false;
            this.FileToRunTextbox.Location = new System.Drawing.Point(1209, 768);
            this.FileToRunTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileToRunTextbox.Name = "FileToRunTextbox";
            this.FileToRunTextbox.ReadOnly = true;
            this.FileToRunTextbox.Size = new System.Drawing.Size(378, 26);
            this.FileToRunTextbox.TabIndex = 59;
            this.FileToRunTextbox.Visible = false;
            // 
            // RunConsoleApplicationButton
            // 
            this.RunConsoleApplicationButton.Enabled = false;
            this.RunConsoleApplicationButton.Location = new System.Drawing.Point(1209, 808);
            this.RunConsoleApplicationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RunConsoleApplicationButton.Name = "RunConsoleApplicationButton";
            this.RunConsoleApplicationButton.Size = new System.Drawing.Size(378, 37);
            this.RunConsoleApplicationButton.TabIndex = 60;
            this.RunConsoleApplicationButton.Text = "Run Console Application";
            this.RunConsoleApplicationButton.UseVisualStyleBackColor = true;
            this.RunConsoleApplicationButton.Visible = false;
            this.RunConsoleApplicationButton.Click += new System.EventHandler(this.RunConsoleApplicationButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 869);
            this.Controls.Add(this.RunConsoleApplicationButton);
            this.Controls.Add(this.FileToRunTextbox);
            this.Controls.Add(this.DateAttributeCombobox);
            this.Controls.Add(this.LoadFromFileButton);
            this.Controls.Add(this.EndDate2Label);
            this.Controls.Add(this.EndDate2DateTimePicker);
            this.Controls.Add(this.StartDate2Label);
            this.Controls.Add(this.StartDate2DateTimePicker);
            this.Controls.Add(this.EndDate1Label);
            this.Controls.Add(this.EndDate1DateTimePicker);
            this.Controls.Add(this.StartDate1Label);
            this.Controls.Add(this.StartDate1DateTimePicker);
            this.Controls.Add(this.BrowseOutputFolderButton);
            this.Controls.Add(this.FilePerMeasureGroupCheckbox);
            this.Controls.Add(this.OtherSettingsLabel);
            this.Controls.Add(this.DateDimensionLabel);
            this.Controls.Add(this.OutputFolderTextbox);
            this.Controls.Add(this.OutputFolderLabel);
            this.Controls.Add(this.SummaryThresholdsLabel);
            this.Controls.Add(this.MaximumPercentageTextbox);
            this.Controls.Add(this.MaximumPercentageLabel);
            this.Controls.Add(this.MaximumDifferenceTextbox);
            this.Controls.Add(this.MaximumDifferenceLabel);
            this.Controls.Add(this.SearchFiltersButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cube2Textbox);
            this.Controls.Add(this.Cube2Label);
            this.Controls.Add(this.Catalog2Textbox);
            this.Controls.Add(this.Catalog2Label);
            this.Controls.Add(this.Datasource2Textbox);
            this.Controls.Add(this.Datasource2Label);
            this.Controls.Add(this.Cube2InfoLabel);
            this.Controls.Add(this.Cube1InfoLabel);
            this.Controls.Add(this.SearchFiltersListBox);
            this.Controls.Add(this.MoveToAvailableFiltersButton);
            this.Controls.Add(this.MoveToQueryFiltersButton);
            this.Controls.Add(this.QueryFiltersLabel);
            this.Controls.Add(this.AvailableFiltersLabel);
            this.Controls.Add(this.QueryFiltersListBox);
            this.Controls.Add(this.AvailableFiltersListBox);
            this.Controls.Add(this.MoveToAvailableAttributesButton);
            this.Controls.Add(this.MoveToQueryAttributesButton);
            this.Controls.Add(this.QueryAttributesLabel);
            this.Controls.Add(this.AvailableAttributeLabel);
            this.Controls.Add(this.QueryAttributesListbox);
            this.Controls.Add(this.AvailableAttributesListbox);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.GetCubeInfoButton);
            this.Controls.Add(this.Cube1Textbox);
            this.Controls.Add(this.Cube1Label);
            this.Controls.Add(this.Catalog1Textbox);
            this.Controls.Add(this.Catalog1Label);
            this.Controls.Add(this.Datasource1Textbox);
            this.Controls.Add(this.Datasource1Label);
            this.Controls.Add(this.MoveToAvailableMeasuresButton);
            this.Controls.Add(this.MoveToQueryMeasuresButton);
            this.Controls.Add(this.QueryMeasuresLabel);
            this.Controls.Add(this.AvailableMeasuresLabel);
            this.Controls.Add(this.QueryMeasuresListBox);
            this.Controls.Add(this.AvailableMeasuresListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AvailableMeasuresListBox;
        private System.Windows.Forms.ListBox QueryMeasuresListBox;
        private System.Windows.Forms.Label AvailableMeasuresLabel;
        private System.Windows.Forms.Label QueryMeasuresLabel;
        private System.Windows.Forms.Button MoveToQueryMeasuresButton;
        private System.Windows.Forms.Button MoveToAvailableMeasuresButton;
        private System.Windows.Forms.Label Datasource1Label;
        private System.Windows.Forms.TextBox Datasource1Textbox;
        private System.Windows.Forms.TextBox Catalog1Textbox;
        private System.Windows.Forms.Label Catalog1Label;
        private System.Windows.Forms.TextBox Cube1Textbox;
        private System.Windows.Forms.Label Cube1Label;
        private System.Windows.Forms.Button GetCubeInfoButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Button MoveToAvailableAttributesButton;
        private System.Windows.Forms.Button MoveToQueryAttributesButton;
        private System.Windows.Forms.Label QueryAttributesLabel;
        private System.Windows.Forms.Label AvailableAttributeLabel;
        private System.Windows.Forms.ListBox QueryAttributesListbox;
        private System.Windows.Forms.ListBox AvailableAttributesListbox;
        private System.Windows.Forms.Button MoveToAvailableFiltersButton;
        private System.Windows.Forms.Button MoveToQueryFiltersButton;
        private System.Windows.Forms.Label QueryFiltersLabel;
        private System.Windows.Forms.Label AvailableFiltersLabel;
        private System.Windows.Forms.ListBox QueryFiltersListBox;
        private System.Windows.Forms.ListBox AvailableFiltersListBox;
        private System.Windows.Forms.ListBox SearchFiltersListBox;
        private System.Windows.Forms.Label Cube1InfoLabel;
        private System.Windows.Forms.Label Cube2InfoLabel;
        private System.Windows.Forms.TextBox Cube2Textbox;
        private System.Windows.Forms.Label Cube2Label;
        private System.Windows.Forms.TextBox Catalog2Textbox;
        private System.Windows.Forms.Label Catalog2Label;
        private System.Windows.Forms.TextBox Datasource2Textbox;
        private System.Windows.Forms.Label Datasource2Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchFiltersButton;
        private System.Windows.Forms.Label SummaryThresholdsLabel;
        private System.Windows.Forms.TextBox MaximumPercentageTextbox;
        private System.Windows.Forms.Label MaximumPercentageLabel;
        private System.Windows.Forms.TextBox MaximumDifferenceTextbox;
        private System.Windows.Forms.Label MaximumDifferenceLabel;
        private System.Windows.Forms.Label OtherSettingsLabel;
        private System.Windows.Forms.Label DateDimensionLabel;
        private System.Windows.Forms.TextBox OutputFolderTextbox;
        private System.Windows.Forms.Label OutputFolderLabel;
        private System.Windows.Forms.CheckBox FilePerMeasureGroupCheckbox;
        private System.Windows.Forms.Button BrowseOutputFolderButton;
        private System.Windows.Forms.DateTimePicker StartDate1DateTimePicker;
        private System.Windows.Forms.Label StartDate1Label;
        private System.Windows.Forms.Label EndDate1Label;
        private System.Windows.Forms.DateTimePicker EndDate1DateTimePicker;
        private System.Windows.Forms.Label EndDate2Label;
        private System.Windows.Forms.DateTimePicker EndDate2DateTimePicker;
        private System.Windows.Forms.Label StartDate2Label;
        private System.Windows.Forms.DateTimePicker StartDate2DateTimePicker;
        private System.Windows.Forms.Button LoadFromFileButton;
        private System.Windows.Forms.ComboBox DateAttributeCombobox;
        private System.Windows.Forms.TextBox FileToRunTextbox;
        private System.Windows.Forms.Button RunConsoleApplicationButton;
    }
}