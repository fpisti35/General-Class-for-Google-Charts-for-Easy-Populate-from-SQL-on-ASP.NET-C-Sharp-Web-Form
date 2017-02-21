using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Diagnostics;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Text;


public class Chart
{
    /***************************************************************************************
    * Goggle API must be insert to page heading section
    * <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    * 
    * A lot of other option parameters available to charts. If you want to add someting else 
    * please visit: https://developers.google.com/chart/
    * 
    *****************************************************************************************/
    

    string sConnection = ConfigurationManager.ConnectionStrings["ChartsConn"].ConnectionString;

    public static SqlDataReader ExecuteReader(string sConnectionString, string sStoredProc, List<string> sParams)
    {
        SqlConnection objConn = new SqlConnection(sConnectionString);
        
        using (SqlCommand objCommand = new SqlCommand(sStoredProc, objConn))
        {
            objConn.Open();
            objCommand.CommandType = CommandType.StoredProcedure;

            foreach (string myparam in sParams)
            {
                string sName = "";
                string sValue = "";
                sName = myparam.Substring(0, myparam.IndexOf(":"));
                sValue = myparam.Substring(myparam.IndexOf(":") + 1);

                objCommand.Parameters.Add(sName, SqlDbType.VarChar).Value = sValue;
            }            
            
            SqlDataReader reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }        
    }

    /*********************************************
    * 
    * Call SP to populate Basic Google Chart
    * 
    * Use for:
    * -AreaChart
    * -BarChart
    * -BubbleChart
    * -ColumnChart
    * -LineChart
    * -ScatterChart
    * -SteppedAreaChart
    * 
    **********************************************/

    public void SP_populateBasicGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType, 
        int iWidth, int iHeight, string sTableName, string shAxisName, string shAxisNameColor,
        string svAxisName, string svAxisNameColor, string[] aColumnNames, string[] aDBFieldNames,
        List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages: ['corechart', 'bar']});
                        google.charts.setOnLoadCallback(drawChart);
                        function drawChart() {
                        var data = new google.visualization.DataTable();");
        str.Append("data.addColumn('string', '" + shAxisName + "');");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            str.Append("data.addColumn('number', '" + aColumnNames[i] + "');");
        }

        // sample format    ['Year', 'Sales', 'Expenses'],
        //                  ['2013',  1000,      400],
        str.Append("data.addRows(" + dt.Rows.Count + ");");

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            for (int j = 0; j < aDBFieldNames.Length; j++)
            {
                str.Append("data.setValue(" + i + "," + j + ",'" + dt.Rows[i][aDBFieldNames[j]].ToString() + "') ;");
            }
        }

        str.Append(" var chart = new google.visualization." + sChartType + "(document.getElementById('" + sDivOrPanelID + "'));");
        
        str.Append(" chart.draw(data, {width: " + iWidth + ", height: " + iHeight +
                    ", title: '" + sTableName + "',");
        str.Append("hAxis: {title: '" + shAxisName + "', titleTextStyle: {color: '" + shAxisNameColor + "'}},");
        str.Append("vAxis: {title: '" + svAxisName + "', titleTextStyle: {color: '" + svAxisNameColor + "'}}");
        str.Append("}); }");
        str.Append("</script>");
        lt.Text = str.ToString();

        objDataReader.Close();       
    }

    // Basic charts with bar's onlick funtions
    public void SP_populateClickableBasicGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string sTableName, string shAxisName, string shAxisNameColor,
        string svAxisName, string svAxisNameColor, string[] aColumnNames, string[] aDBFieldNames,
        List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages: ['corechart', 'bar']});
                        google.charts.setOnLoadCallback(drawChart);
                        function drawChart() {
                        var data = new google.visualization.DataTable();");
        str.Append("data.addColumn('string', '" + shAxisName + "');");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            str.Append("data.addColumn('number', '" + aColumnNames[i] + "');");
        }

        // sample format    ['Year', 'Sales', 'Expenses'],
        //                  ['2013',  1000,      400],
        str.Append("data.addRows(" + dt.Rows.Count + ");");

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            for (int j = 0; j < aDBFieldNames.Length; j++)
            {
                str.Append("data.setValue(" + i + "," + j + ",'" + dt.Rows[i][aDBFieldNames[j]].ToString() + "') ;");
            }
        }

        str.Append(" var chart = new google.visualization." + sChartType + "(document.getElementById('" + sDivOrPanelID + "'));");

        str.Append("google.visualization.events.addListener(chart, 'select', function () { " +
            "var selection = chart.getSelection(); if (selection.length) { " +
            "var row = selection[0].row; " +
            "var col = selection[0].column; " +
            "var value = data.getValue(row, col); " +
            "/* location.href = 'http://www.example.com?row=' + row + '&col=' + col + '&year=' + value; */" +
            "displayDetails(row, col, value); }" +
            "});");

        str.Append(" chart.draw(data, {width: " + iWidth + ", height: " + iHeight +
                    ", title: '" + sTableName + "',");
        str.Append("hAxis: {title: '" + shAxisName + "', titleTextStyle: {color: '" + shAxisNameColor + "'}},");
        str.Append("vAxis: {title: '" + svAxisName + "', titleTextStyle: {color: '" + svAxisNameColor + "'}}");
        str.Append("}); }");
        str.Append("</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Calendar Google Chart
    *      
    * Note: JavaScript counts months starting at zero: January is 0, February is 1, 
    * and December is 11. If your calendar chart seems off by a month, this is why.
    * 
    **********************************************/
    public void SP_populateCalendarGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iHeight, string sTableName, string[] aColumnNames, string[] aDBFieldNames,
        List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load(*current*, {packages:[*calendar*]});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var dataTable = new google.visualization.DataTable();");
       str.Append("dataTable.addColumn({ type: 'date', id: '" + aColumnNames[0] + "' });");
       str.Append("dataTable.addColumn({ type: 'number', id: '" + aColumnNames[1] + "' });");
       str.Append("dataTable.addRows([");

       // sample format [ new Date(2013, 9, 4), 38177 ], month must reduce with -1 !!!!!!!
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            DateTime datevalue = (Convert.ToDateTime(dt.Rows[i][aDBFieldNames[0]].ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
            
            str.Append("[ new Date(" + yy + ", " + (Convert.ToInt32(mn)-1) + ", " + dy + 
                "), " + dt.Rows[i][aDBFieldNames[1]].ToString() + " ],");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" + sDivOrPanelID + "'));");
        str.Append("var options = { title: '" + sTableName + "', height: " + iHeight + " };");
        str.Append("chart.draw(dataTable, options);");        
        str.Append("}</script>");
        lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');        

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Candlestick Google Chart
    *          
    **********************************************/
    public void SP_populateCandleGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
         int iWidth, int iHeight, string sTableName, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load(*current*, {packages:[*corechart*]});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.arrayToDataTable([");


        // sample format ['Mon', 20, 28, 38, 45], month must reduce with -1 !!!!!!!
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "' ," +
                dt.Rows[i][aDBFieldNames[1]].ToString() +  ", " +
                dt.Rows[i][aDBFieldNames[2]].ToString() + ", " +
                dt.Rows[i][aDBFieldNames[3]].ToString() + ", " +
                dt.Rows[i][aDBFieldNames[4]].ToString());
            if (i <  (dt.Rows.Count - 1))
            {
                str.Append("],");
            }
            else
            {
                str.Append("]");
            }                
        }

        str.Append("], true); var chart = new google.visualization." + sChartType + "(document.getElementById('" + sDivOrPanelID + "'));");
        str.Append("var options = {width: " + iWidth + ", height: " + iHeight + ", legend:'none' , title: '" + sTableName +  "'};");
        str.Append("chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Combo Google Chart
    *    
    **********************************************/
    public void SP_populateComboGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string sTableName, string shAxisName, string shAxisNameColor,
        string svAxisName, string svAxisNameColor, string[] aColumnNames, string[] aDBFieldNames, 
        List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load(*current*, {packages:[*corechart*]});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.arrayToDataTable([[");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            if (i < (aColumnNames.Length - 1))
            {
                str.Append("'" + aColumnNames[i] + "',");
            }
            else
            {
                str.Append("'" + aColumnNames[i] + "'],");
            }
        }

        // sample format ['Month', 'Bolivia', 'Ecuador', 'Madagascar', 'Papua New Guinea', 'Rwanda', 'Average'],
        //               ['2004/05',  165,      938,         522,             998,           450,      614.6],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'");
            for (int j = 1; j < aDBFieldNames.Length; j++)
            {
                str.Append(", " + dt.Rows[i][aDBFieldNames[j]].ToString());
            } 
            
            if (i < (dt.Rows.Count - 1))
            {
                str.Append("],");
            }
            else
            {
                str.Append("]");
            }
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" + sDivOrPanelID + "'));");
        str.Append("var options = {width: " + iWidth + ", height: " + iHeight + ", title: '" + sTableName + "',");
        str.Append("hAxis: {title: '" + shAxisName + "', titleTextStyle: {color: '" + shAxisNameColor + "'}},");
        str.Append("vAxis: {title: '" + svAxisName + "', titleTextStyle: {color: '" + svAxisNameColor + "'}},");
        str.Append("seriesType: 'bars', series: {" + (aColumnNames.Length-2) + ": {type: 'line'}}");
        str.Append("}; chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Single Value Google Chart
    * 
    * Use for:
    * -DonutChart
    * -PieChart
    * -3D PieChart
    *     
    * *********************************************/
    public void SP_populateSingleValueGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string sTableName, string[] aColumnNames, string[] aDBFieldNames,
        List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load(*current*, {packages:[*corechart*]});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.arrayToDataTable([");

        str.Append("['" + aColumnNames[0] + "', '" + aColumnNames[0] + "']");
        
        // sample format ['Task', 'Hours per Day'],
        //               ['Work',     11],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                dt.Rows[i][aDBFieldNames[1]].ToString() + "]");            
        }

        str.Append("]); var chart = new google.visualization.PieChart(document.getElementById('" + 
            sDivOrPanelID + "'));");

        if (sChartType == "PieChart")
        {
            str.Append("var options = {width: " + iWidth + ", height: " + iHeight + ", title: '" + 
                sTableName + "'};");
        }
        else if (sChartType == "DonutChart")
        {
            str.Append("var options = {width: " + iWidth + ", height: " + iHeight + ", title: '" + sTableName + 
                "', pieHole: 0.4};"); // set hole manually if you want a different size of hole
        }
        else if (sChartType == "3D PieChart")
        {
            str.Append("var options = {width: " + iWidth + ", height: " + iHeight + ", title: '" + sTableName +
                "', is3D: true};"); 
        }

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Gantt Google Chart
    *     
    * *********************************************/
    public void SP_populateGanttGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        string sdy, smn, syy, edy, emn, eyy = "";

        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['gantt']});
                    google.charts.setOnLoadCallback(drawChart);");

        str.Append("function daysToMilliseconds(days) {return days * 24 * 60 * 60 * 1000;}");

        str.Append("function drawChart() {var data = new google.visualization.DataTable();");        

        str.Append("data.addColumn('string', '" + aColumnNames[0] + "');");
        str.Append("data.addColumn('string', '" + aColumnNames[1] + "');");
        str.Append("data.addColumn('date', '" + aColumnNames[2] + "');");
        str.Append("data.addColumn('date', '" + aColumnNames[3] + "');");
        str.Append("data.addColumn('number', '" + aColumnNames[4] + "');");
        str.Append("data.addColumn('number', '" + aColumnNames[5] + "');");
        str.Append("data.addColumn('string', '" + aColumnNames[6] + "');");

        str.Append("data.addRows([");

        // sample data ['Research', 'Find sources', new Date(2015, 0, 1), 
        //              new Date(2015, 0, 5), null,  100,  null],
        
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            sdy = ""; smn = ""; syy = ""; edy = ""; emn = ""; eyy = "";

            string sDate = dt.Rows[i][aDBFieldNames[2]].ToString();

            if (dt.Rows[i][aDBFieldNames[2]].ToString() != "")
            {
                DateTime start_date = (Convert.ToDateTime(dt.Rows[i][aDBFieldNames[2]].ToString()));

                sdy = start_date.Day.ToString();
                smn = start_date.Month.ToString();
                syy = start_date.Year.ToString();
            }

            if (dt.Rows[i][aDBFieldNames[3]].ToString() != "")
            {
                DateTime end_date = (Convert.ToDateTime(dt.Rows[i][aDBFieldNames[3]].ToString()));

                edy = end_date.Day.ToString();
                emn = end_date.Month.ToString();
                eyy = end_date.Year.ToString();
            }
            

            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'");
            str.Append(", '" + dt.Rows[i][aDBFieldNames[1]].ToString() + "'");

            if (dt.Rows[i][aDBFieldNames[2]].ToString() != "")
            {
                str.Append(", new Date(" + syy + ", " + smn + ", " + sdy + ")");
            }
            else
            {
                str.Append(", null");
            }

            if (dt.Rows[i][aDBFieldNames[3]].ToString() != "")
            {
                str.Append(", new Date(" + eyy + ", " + emn + ", " + edy + ")");
            }
            else
            {
                str.Append(", null");
            }
            str.Append(", daysToMilliseconds(" + dt.Rows[i][aDBFieldNames[4]].ToString() + ")");
            str.Append(", " + dt.Rows[i][aDBFieldNames[5]].ToString());
            str.Append(", '" + dt.Rows[i][aDBFieldNames[6]].ToString() + "'");

            if (i < dt.Rows.Count - 1)
            {
                str.Append("],");
            }
            else
            {
                str.Append("]");
            }
                
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {height: " + iHeight + ", width: " + iWidth + "};");
        
        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Gauge Google Charts
    *     
    * *********************************************/
    public void SP_populateGaugeGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, int iRedFrom, int iRedTo, int iYellowFrom, int iYellowTo, int iMinorTicks, 
        string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['gauge']});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.arrayToDataTable([");

        str.Append("['" + aColumnNames[0] + "', '" + aColumnNames[0] + "']");

        // sample format   ['Label', 'Value'],
        //                 ['Memory', 80],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                dt.Rows[i][aDBFieldNames[1]].ToString() + "]");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {width: " + iWidth + ", height: " + iHeight +
            ", redFrom: " + iRedFrom + ", redTo: " + iRedTo +
            ", yellowFrom: " + iYellowFrom + ", yellowTo: " + iYellowTo +
            ", minorTicks: " + iMinorTicks    + " };");
        

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Geo Google Charts
    *     
    * *********************************************/
    public void SP_populateGeoGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string sRegion, string sDisplayMode, string sColorAxis_1, string sColorAxis_2, 
        string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script src='https://maps.googleapis.com/maps/api/js?key=AIzaSyDRplCsm8BLzdK5Ekft1GIzVIqa9815mTY&callback=initMap' async defer></script>");

        str.Append(@"<script type=text/javascript> google.charts.load('upcoming', {packages:['geochart']});
                    google.charts.setOnLoadCallback(drawMarkersMap);
                    function drawMarkersMap() {
                    var data = new google.visualization.arrayToDataTable([[");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            str.Append("'" + aColumnNames[i] + "'");
            if (i < aColumnNames.Length - 1) { str.Append(", "); }
            else { str.Append("]"); }
        }           

        // sample format    ['City',   'Population', 'Area'],
        //                  ['Rome',      2761477,    1285.31],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                dt.Rows[i][aDBFieldNames[1]].ToString() + ", " +
                dt.Rows[i][aDBFieldNames[2]].ToString() + "]");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {width: " + iWidth + ", height: " + iHeight +
            ", region: '" + sRegion + "', " +
            "displayMode: '" + sDisplayMode + "', " +
            "colorAxis: {colors: ['" + sColorAxis_1 + "', '" + sColorAxis_2 + "']}};");

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Histogram Google Charts
    *     
    * *********************************************/
    public void SP_populateHistogramGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string sTitle, string sLegendPosition, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();        

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['corechart']});
                    google.charts.setOnLoadCallback(drawMarkersMap);
                    function drawMarkersMap() {
                    var data = new google.visualization.arrayToDataTable([[");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            str.Append("'" + aColumnNames[i] + "'");
            if (i < aColumnNames.Length - 1) { str.Append(", "); }
            else { str.Append("]"); }
        }

        // sample format    ['Dinosaur', 'Length'],
        //                  ['Acrocanthosaurus (top-spined lizard)', 12.2],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                dt.Rows[i][aDBFieldNames[1]].ToString() + "]");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {width: " + iWidth + ", height: " + iHeight +
            ", title: '" + sTitle + "', legend: { position: '" + sLegendPosition + "' },};");

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Map Google Charts
    *     
    * *********************************************/
    public void SP_populateMapGoogleChart(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        string sShowTooltip, string sShowInfoWindow, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script src='https://maps.googleapis.com/maps/api/js?key=AIzaSyCf-i_QNL-8RIULvwupOCqbVGuf2zQCJW4&callback=initMap' async defer></script>");

        str.Append(@"<script type=text/javascript> function initMap() { google.charts.load('upcoming', {packages:['map']});
                    google.charts.setOnLoadCallback(drawMap);}
                    function drawMap() {
                    var data = new google.visualization.arrayToDataTable([[");

        for (int i = 0; i < aColumnNames.Length; i++)
        {
            str.Append("'" + aColumnNames[i] + "'");
            if (i < aColumnNames.Length - 1) { str.Append(", "); }
            else { str.Append("]"); }
        }

        // sample format    ['Country', 'Population'],
        //                  ['China', 'China: 1,363,800,000'],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "','" +
                dt.Rows[i][aDBFieldNames[1]].ToString() +  "']");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {showTooltip: " + sShowTooltip +
            ", showInfoWindow: " + sShowInfoWindow + "};");

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Sankey Diagrams
    *     
    * *********************************************/
    public void SP_populateSankeyDiagrams(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['sankey']});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.DataTable();");

        str.Append("data.addColumn('string', '" + aColumnNames[0] + "');");
        str.Append("data.addColumn('string', '" + aColumnNames[1] + "');");
        str.Append("data.addColumn('number', '" + aColumnNames[2] + "');");
        str.Append("data.addRows([");

        // sample format    [ 'A', 'X', 5 ],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "','" +
                dt.Rows[i][aDBFieldNames[1]].ToString() + "', " +
                dt.Rows[i][aDBFieldNames[2]].ToString());
                if (i < dt.Rows.Count - 1) {
                    str.Append(" ],");
                }
                else
                {
                    str.Append(" ]]);");
                }
        }

        str.Append("var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {width: " + iWidth + "};");

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Table
    *     
    * *********************************************/
    public void SP_populateTable(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        string sShowRowNumber, string sWidth, string sHeight, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['table']});
                    google.charts.setOnLoadCallback(drawTable);
                    function drawTable() {
                    var data = new google.visualization.DataTable();");

        str.Append("data.addColumn('string', '" + aColumnNames[0] + "');");
        str.Append("data.addColumn('number', '" + aColumnNames[1] + "');");
        str.Append("data.addColumn('boolean', '" + aColumnNames[2] + "');");
        str.Append("data.addRows([");

        // sample format    ['Mike',  {v: 10000, f: '$10,000'}, true],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                " {v: " + dt.Rows[i][aDBFieldNames[1]].ToString() + ", " +
                " f: '" + dt.Rows[i][aDBFieldNames[2]].ToString() + "'}, " +
                dt.Rows[i][aDBFieldNames[3]].ToString());
            if (i < dt.Rows.Count - 1)
            {
                str.Append(" ],");
            }
            else
            {
                str.Append(" ]]);");
            }
        }

        str.Append("var table = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {showRowNumber: " + sShowRowNumber +
            ", width: '" + sWidth + "', height: '" + sHeight + "'};");

        str.Append(" table.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }


    /*********************************************
    * 
    * Call SP to populate Timeline
    *     
    * *********************************************/
    public void SP_populateTimeline(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        int iWidth, int iHeight, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {

        string sdy, smn, syy, edy, emn, eyy = "";
        
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();

        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['timeline']});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var container = document.getElementById('" + sDivOrPanelID + "');" +
                    "var chart = new google.visualization." + sChartType + "(container); " +
                    "var dataTable = new google.visualization.DataTable();");

        str.Append("dataTable.addColumn({ type: 'string', id: '" + aColumnNames[0] + "' });");
        str.Append("dataTable.addColumn({ type: 'date', id: '" + aColumnNames[1] + "' });");
        str.Append("dataTable.addColumn({ type: 'date', id: '" + aColumnNames[2] + "' });");
        str.Append("dataTable.addRows([");

        // sample format    [ 'Washington', new Date(1789, 3, 30), new Date(1797, 2, 4) ],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            sdy = ""; smn = ""; syy = ""; edy = ""; emn = ""; eyy = "";

            string sDate = dt.Rows[i][aDBFieldNames[1]].ToString();

            if (dt.Rows[i][aDBFieldNames[1]].ToString() != "")
            {
                DateTime start_date = (Convert.ToDateTime(dt.Rows[i][aDBFieldNames[1]].ToString()));

                sdy = start_date.Day.ToString();
                smn = start_date.Month.ToString();
                syy = start_date.Year.ToString();
            }

            if (dt.Rows[i][aDBFieldNames[2]].ToString() != "")
            {
                DateTime end_date = (Convert.ToDateTime(dt.Rows[i][aDBFieldNames[2]].ToString()));

                edy = end_date.Day.ToString();
                emn = end_date.Month.ToString();
                eyy = end_date.Year.ToString();
            }

            str.Append("['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "'," +
                " new Date(" + syy + ", " + smn + ", " + sdy + ")," +
                " new Date(" + eyy + ", " + emn + ", " + edy + ") " );
            if (i < dt.Rows.Count - 1)
            {
                str.Append("],");
            }
            else
            {
                str.Append("]]);");
            }
        }
        
        str.Append("var options = {width: '" + iWidth + "', height: '" + iHeight + "'};");

        str.Append(" chart.draw(dataTable, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }

    /*********************************************
    * 
    * Call SP to populate Word Tree
    *     
    * *********************************************/
    public void SP_populateWordTree(Literal lt, string sDivOrPanelID, string sStoredProc, string sChartType,
        string sFormat, string sWord, string[] aColumnNames, string[] aDBFieldNames, List<string> sParams)
    {
        DataTable dt = new DataTable();
        SqlDataReader objDataReader = ExecuteReader(sConnection, sStoredProc, sParams);

        dt.Load(objDataReader);

        StringBuilder str = new StringBuilder();


        str.Append(@"<script type=text/javascript> google.charts.load('current', {packages:['wordtree']});
                    google.charts.setOnLoadCallback(drawChart);
                    function drawChart() {
                    var data = new google.visualization.arrayToDataTable(");

        str.Append("[['" + aColumnNames[0] + "']");
       

        // sample format    ['Phrases'],
        //                  ['cats are better than dogs'],
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            str.Append(",['" + dt.Rows[i][aDBFieldNames[0]].ToString() + "']");
        }

        str.Append("]); var chart = new google.visualization." + sChartType + "(document.getElementById('" +
            sDivOrPanelID + "'));");

        str.Append("var options = {wordtree: {format: '" + sFormat + "', " +
            "word: '" + sWord + "'}};");

        str.Append(" chart.draw(data, options);");
        str.Append("}</script>");
        lt.Text = str.ToString();

        objDataReader.Close();
    }
}
