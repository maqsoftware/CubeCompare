# Cube Compare Tool

The Cube Compare Tool is a utility that automates thorough comparisons between two similar cubes. The tool can perform comparisons based on specific criteria provided in a settings file. The settings file can be generated via a GUI that will show available metrics in the cubes you wish to compare. The results of each comparison are in the form of one or more excel documents with details and a summary. 

# How-To Configure
This section describes how to use the utility. The general workflow would be to use the GUI to create a settings file, then pass that file to the console application.

# Using the console application
The console application requires only the settings file to run. This file can be given as an input to the console application in two ways.
Primarily, the console application receives the settings file location as a command line argument. For example:

__CubeCompare-Console.exe C:\settings\cubecomparesettings.xlsx__

The second way would be to supply the location in the accompanying configuration xml file. The structure of the *CubeCompare-Console.exe.xml* xml file is as follows:

&lt;configuration&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;startup&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" /&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/startup&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;appSettings&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key="SettingsLocation" value="" /&gt; <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/appSettings&gt; <br/>
&lt;/configuration&gt; <br/>


Note that the settings location is the value of the key _SettingsLocation_.

The command line argument input will have priority over the location in the xml file. If neither option is specified, then the application will quit with an error displayed.

# Using the GUI

The following sections shows the components of the Cube Compare GUI. The Cube Compare GUI composes settings files such that each input measures is queried with each input dimension, and all the filters, date range settings, and thresholds apply to each query.

# Cube Information

The cube information sections of the GUI (Cube 2 Information and Cube 2 Information) are the connection details for each cube and some optional date range.

Each set of cube information has the following inputs:
  * Datasource: The server of the cube.
  * Catalog: The catalog or database the cube is contained in.
  * Cube: The name of the cube.
  * Start Date: The starting date of the time range to filter for in queries to the cube.
  * End Date: The end date of the time range to filter for in queries to the cube.

Note that the Start Date and End Date depends on the date Attribute setting in the Other Settings section. These date inputs are optional.

Once the cube information has been filled in, the _Get Cube Info (Cube 1)_ button will populate other input options.

# Measures and Attributes
For both measures and attributes, there are two sections, the _Available_ list box, and the _to Query_ list box.

The _Available_ list boxes are populated by the _Get Cube Info (Cube 1)_ button and shows available measures, and the available attributes. These can then be moved to the to the _to Query_ list boxes by selecting measures or attributes and clicking the move right button (>>). Likewise, selecting from the _to Query_ list boxes and clicking the move left button (<<) will move the measures or attributes back.
Items in the _To Query_ list boxes are saved to the settings file when the users saves with the _Save As_ button. 

# Filters
As most cubes contains an enormous number of members over all, filters are first searched by their corresponding dimension attribute.
The Search for filters list box is populated with attributes by the _Get Cube Info (Cube 1)_ button. A user can then select a set of attributes and press the _Search by selection_ button to populate the Available filters list box with the attributes’ members.
Like the Measure and Attribute list boxes, a user can use the move right (>>) and the move left (<<) to select and deselect which filters to include in the settings file.

# Summary Thresholds
The summary thresholds determine at which difference or percent difference or more will a record be saved to the summary spreadsheet.

# Other Settings
There are only three other settings:
  * Output folder: The location of the output for the resulting results for the console application. The Browse for Output Folder button can be used locate the folder using a system dialog.
  * Date Attribute (Unique Name): This is a combo box populated by the _Get Cube Info (Cube 1)_ button. It is used to denote the date attribute in a cube for the date range settings in the Cube Information section.
  * Excel file per measure group: This is a check box setting whether to split the resulting reports by measure group into separate excel files or not.

# Saving and Loading
Use the _Save As_ button to save. This opens a system dialog to choose the save location.
Use the _Load From File_ button to load an existing cube compare settings file. 
After using either the _Save As_ or _Load From File_ buttons, an additional textbox and button should appear. This textbox contains the file path to the file saved or loaded. The _Run Console Application_ button runs the console application on this file path if the console application is the same directory as the GUI application.

# Understanding the output
This section describes the output that is sent by the utility. The output is in the form of one or more excel documents, each with a single summary and one spreadsheet per query generated.

# Understanding the summary spreadsheet
The first two rows of the summary spreadsheet contain the cube connection information.
A single table is also included in the summary spreadsheet. This table will contain all the records which surpassed the given thresholds.
The table contains the following:

|Column Name	|Definition|
|-------------|----------|
|Report	      |Which report (spreadsheet name) the record originated from.|
|Measure	|The name of the measure queried.|
|Dimension - Attribute		|By which attribute was the measure sliced.|
|Member (row labels)	|The member (of the Dimension – Attribute) for the record.|
|[Cube 1]	|The result of the query for [Cube 1].|
|[Cube 2]	|The result of the query for [Cube 2].|
|Difference	|The difference from cube 1 to cube 2. (Cube 2 – Cube 1)|
|Percent Difference	|The percent difference from cube 1 to cube 2. (Cube 2 – Cube 1) /2.|

# Understanding the detailed reports
The individual reports are spreadsheets containing the results for the individual queries ran on both cubes.
The first four rows contain:

1. The measures being queried
2. The attribute by which the member was queried
3. The filters used to limit the dataset
4. The MDX query that generated the result (For Cube 1 differences may arise if date ranges are used)
Each report spreadsheet also contains a table detailing the results of the query. 

|Column Name	|Definition|
|-------------|----------|
|[Attribute]	|The members of the [Attribute]|
|[Cube 1]	|The result of the query for [Cube 1].|
|[Cube 2]	|The result of the query for [Cube 2].|
|Difference	|The difference from cube 1 to cube 2. (Cube 2 – Cube 1)|
|Percent Difference	|The percent difference from cube 1 to cube 2. (Cube 2 – Cube 1) /2.|
