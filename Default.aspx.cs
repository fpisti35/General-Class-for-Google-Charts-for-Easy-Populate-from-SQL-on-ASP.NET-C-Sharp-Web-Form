using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    
    string sChartType = "ColumnChart";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            chkOnclick.Visible = true;

            populateDropDownFromArray();
            displayBasicCharts();            
        }
    }

    private void populateDropDownFromArray()
    {

        string[] aChartNames = new string[] { "3D PieChart", "AreaChart", "BarChart", "BubbleChart", "Calendar", 
            "CandlestickChart", "ColumnChart", "ComboChart", "DonutChart", "Gantt", "Gauge", "GeoChart",
            "Histogram", "LineChart", "Map", "PieChart", "Sankey", "ScatterChart", "SteppedAreaChart",
            "Table", "Timeline", "WordTree" };

        List<System.Web.UI.WebControls.ListItem> chartTypes = new List<System.Web.UI.WebControls.ListItem>();

        for (int i = 0; i < aChartNames.Length; i++)
        {
            chartTypes.Add(new ListItem(aChartNames[i]));
        }

        ddlCharType.DataSource = chartTypes;
        ddlCharType.DataBind();

        ddlCharType.SelectedValue = "ColumnChart";
    }

    protected void ddlCharType_SelectedIndexChanged(object sender, EventArgs e)
    {
        sChartType = ddlCharType.SelectedValue.ToString();
        if (sChartType == "AreaChart" || sChartType == "BarChart" || // basic charts
            sChartType == "BubbleChart" || sChartType == "ColumnChart" ||
            sChartType == "LineChart" || sChartType == "ScatterChart" ||
            sChartType == "SteppedAreaChart")
        {
            chkOnclick.Visible = true;
            displayBasicCharts();
        }
        else if (sChartType == "Calendar") { displayCalendarChart(); chkOnclick.Visible = false; }
        else if (sChartType == "CandlestickChart") { displayCandlestickChart(); chkOnclick.Visible = false; }
        else if (sChartType == "ComboChart") { displayComboChartChart(); chkOnclick.Visible = false; }
        else if (sChartType == "DonutChart" || sChartType == "PieChart" ||
            sChartType == "3D PieChart")
        {
            displaySingleValueChart();
            chkOnclick.Visible = false;
        }
        else if (sChartType == "Gantt") { displayGanttChart(); chkOnclick.Visible = false; }
        else if (sChartType == "Gauge") { displayGaugeChart(); chkOnclick.Visible = false; }
        else if (sChartType == "GeoChart") { displayGeoChart(); chkOnclick.Visible = false; }
        else if (sChartType == "Histogram") { displayHistograms(); chkOnclick.Visible = false; }
        else if (sChartType == "Map") { displayMap(); chkOnclick.Visible = false; }
        else if (sChartType == "Sankey") { displaySankey(); chkOnclick.Visible = false; }
        else if (sChartType == "Table") { displayTable(); chkOnclick.Visible = false; }
        else if (sChartType == "Timeline") { displayTimeline(); chkOnclick.Visible = false; }
        else if (sChartType == "WordTree") { displayWordTree(); chkOnclick.Visible = false; }
        else { displayBasicCharts(); }        
    }     

    private void displayBasicCharts()
    {
        // names for bars
        string[] aColumnNames = new string[] { "Sales", "Expenses", "Cash", "Credit Card", "Online", "Retailer" };
        
        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Year", "Sales", "Expenses", "Cash", "CreditCard", "Online", "Retailer" };
        
        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");
        
        Chart ch = new Chart();

        /***************
         * Parameter's definition
         * 1, Literal ID
         * 2, Element ID for chart load to, div on panel booth usable
         * 3, Stored Procedor name
         * 4, Type of chart, you can choose one from aChartNames below
         * 5-6, Width and heigth
         * 7, Chart title
         * 8, hAxis name
         * 9, hAxis name color
         * 10, vAxis name
         * 11, vAxis name color
         * 12, Array for name of columns
         * 13, Array for database column names
         * 14, A list from Stored Procedors parameters
         ****************/

        if (chkOnclick.Checked)
        {
            ch.SP_populateClickableBasicGoogleChart(lt, "pnlChart", "IF_READ_MV_TO_CHART", sChartType, 800, 600,
        "Company Performance", "Years", "green", "Values", "red", aColumnNames, aDBFieldNames, sParams); 
        }
        else
        {
            ch.SP_populateBasicGoogleChart(lt, "pnlChart", "IF_READ_MV_TO_CHART", sChartType, 800, 600,
        "Company Performance", "Years", "green", "Values", "red", aColumnNames, aDBFieldNames, sParams); 
        }
    }   


    private void displayCalendarChart()
    {
        // names for bars
        string[] aColumnNames = new string[] { "Date", "Won/Loss" };

        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Date", "Value" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
         * Parameter's definition
         * 1, Literal ID
         * 2, Element ID for chart load to, div on panel booth usable
         * 3, Stored Procedor name
         * 4, Type of chart, you can choose one from aChartNames below
         * 5, Heigth, Warning !!!! 'Width' reduce the displayed moths !!!!!
         * 6, Chart title
         * 7, Array for name of columns ( a pair: date and value)
         * 8, Array for database column names ( a pair: date and value)
         * 9, A list from Stored Procedors parameters
         ****************/

        ch.SP_populateCalendarGoogleChart(lt, "pnlChart", "IF_READ_CALENDAR_TO_CHART", sChartType, 600,
        "Company Performance",  aColumnNames, aDBFieldNames, sParams);
    }


    private void displayCandlestickChart()
    {
        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Days", "val1", "val2", "val3", "val4" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
         * Parameter's definition
         * 1, Literal ID
         * 2, Element ID for chart load to, div on panel booth usable
         * 3, Stored Procedor name
         * 4, Type of chart, you can choose one from aChartNames below 
         * 5-6, Width and heigth
         * 7, Array for database column names (a name and two pairs numbers, display format: 1-4, 2-3 )
         * 8, A list from Stored Procedors parameters
         ****************/

        ch.SP_populateCandleGoogleChart(lt, "pnlChart", "IF_READ_CANDLE_TO_CHART", sChartType,
          600, 400, "Company Performance", aDBFieldNames, sParams);
    }

    public void displayComboChartChart()
    {
        // names for bars
        string[] aColumnNames = new string[] { "Year", "Sales", "Expenses", "Cash", "Credit Card", "Online", "Retailer", "Average" };

        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Year", "Sales", "Expenses", "Cash", "CreditCard", "Online", "Retailer", "Average" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

         /***************
         * Parameter's definition
         * 1, Literal ID
         * 2, Element ID for chart load to, div on panel, booth usable
         * 3, Stored Procedor name
         * 4, Type of chart, you can choose one from aChartNames below
         * 5-6, Width and heigth
         * 7, Chart title
         * 8, hAxis name
         * 9, hAxis name color
         * 10, vAxis name
         * 11, vAxis name color
         * 12, Array for name of columns
         * 13, Array for database column names
         * 14, A list from Stored Procedors parameters
         ****************/

        ch.SP_populateComboGoogleChart(lt, "pnlChart", "IF_READ_MV_TO_CHART", sChartType,
          600, 480, "Company Performance", "Years", "green", "Values", "red", aColumnNames, 
          aDBFieldNames, sParams);
    }

    private void displaySingleValueChart()
    {
        // names for bars
        string[] aColumnNames = new string[] { "Task", "Hours per Day" };

        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Name", "Value" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-6, Width and heigth
        * 7, Chart title
        * 8, Array for name of columns
        * 9, Array for database column names
        * 10, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateSingleValueGoogleChart(lt, "pnlChart", "IF_READ_SV_TO_CHART", sChartType,
          600, 480, "Company Performance", aColumnNames, aDBFieldNames, sParams);
    }

    private void displayGanttChart()
    {
        // names for bars
        string[] aColumnNames = new string[] { "Task ID", "Task Name", "Start Date", "End Date", "Duration"
            , "Percent Complete", "Dependencies"}; //Important !!! Do not change them !!!!

        // database column names, first usually hold a string for x-axis, and others hold a number for bars 
        string[] aDBFieldNames = new string[] { "Task_ID", "Task_Name", "Start_Date", "End_Date", "Duration"
            , "Percent_Complete", "Dependencies"};

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-6, Width and heigth
        * 7, Array for name of columns
        * 8, Array for database column names
        * 9, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateGanttGoogleChart(lt, "pnlChart", "IF_READ_GANTT_TO_CHART", sChartType,
          600, 480, aColumnNames, aDBFieldNames, sParams);
    }

    private void displayGaugeChart()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "Label", "Value" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "Label", "Value" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-11, Width, heigth, redFrom, redTo, yellowFrom, yellowTo, minorTicks      
        * 12, Array for name of columns
        * 13, Array for database column names
        * 14, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateGaugeGoogleChart(lt, "pnlChart", "IF_READ_GAUGE_TO_CHART", sChartType,
          400, 120, 90, 100, 75, 90, 15, aColumnNames, aDBFieldNames, sParams);
    }

    private void displayGeoChart()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "City", "Population", "Area" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "City", "Population", "Area" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-10, Width, heigth, region, display mode, start color, end color      
        * 11, Array for name of columns
        * 12, Array for database column names
        * 13, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateGeoGoogleChart(lt, "pnlChart", "IF_READ_GEO_TO_CHART", sChartType,
          640, 480, "GB", "markers", "green", "blue", aColumnNames, aDBFieldNames, sParams);
    }

    private void displayHistograms()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "Dinosaur", "Length" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "Name", "Value" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-8, Width, heigth, title, legend position      
        * 9, Array for name of columns
        * 10, Array for database column names
        * 11, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateHistogramGoogleChart(lt, "pnlChart", "IF_READ_HISTOGRAM_TO_CHART", sChartType,
          640, 480, "Lengths of dinosaurs, in meters", "none", aColumnNames, aDBFieldNames, sParams);
    }

    private void displayMap()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "Country", "Population" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "Country", "Population" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-6, showTooltip, showInfoWindow      
        * 7, Array for name of columns
        * 8, Array for database column names
        * 9, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateMapGoogleChart(lt, "pnlChart", "IF_READ_MAP_TO_CHART", sChartType, 
           "true", "true", aColumnNames, aDBFieldNames, sParams);
    }

    private void displaySankey()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "From", "To", "Weight" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "clFrom", "clTo", "clWeight" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5, width    
        * 6, Array for name of columns
        * 7, Array for database column names
        * 8, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateSankeyDiagrams(lt, "pnlChart", "IF_READ_SANKEY_TO_CHART", sChartType, 
           600, aColumnNames, aDBFieldNames, sParams);
    }

    private void displayTable()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "Name", "Salary", "Full Time Employee" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "Name", "SalaryValue", "SalaryFormat", "FullTE" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-7, showRowNumber, width, height    
        * 8, Array for name of columns
        * 9, Array for database column names
        * 10, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateTable(lt, "pnlChart", "IF_READ_DATA_TO_TABLE", sChartType,
           "true", "100%", "100%", aColumnNames, aDBFieldNames, sParams);
    }

    private void displayTimeline()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "President", "Start", "End" };

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "President", "StartDate", "EndDate" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-6, width, height    
        * 7, Array for name of columns
        * 8, Array for database column names
        * 9, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateTimeline(lt, "pnlChart", "IF_READ_DATA_TO_TIMELINE", sChartType,
           640, 240, aColumnNames, aDBFieldNames, sParams);
    }

    private void displayWordTree()
    {
        // names for data heading
        string[] aColumnNames = new string[] { "Phrases"};

        // database column names, sometime different like the label names 
        string[] aDBFieldNames = new string[] { "Phrases" };

        // a list of parameters for stored procedors only!
        List<string> sParams = new List<string>();
        sParams.Clear();

        sParams.Add("@id:" + "sample params");

        Chart ch = new Chart();

        /***************
        * Parameter's definition
        * 1, Literal ID
        * 2, Element ID for chart load to, div on panel, booth usable
        * 3, Stored Procedor name
        * 4, Type of chart, you can choose one from aChartNames below
        * 5-6, format, word    
        * 7, Array for name of columns
        * 8, Array for database column names
        * 9, A list from Stored Procedors parameters
        ****************/

        ch.SP_populateWordTree(lt, "pnlChart", "IF_READ_DATA_TO_WORDTREE", sChartType,
           "implicit", "cats", aColumnNames, aDBFieldNames, sParams);
    }


    protected void chkOnclick_CheckedChanged(object sender, EventArgs e)
    {
        displayBasicCharts();
    }
}