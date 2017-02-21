<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="DisplayDetails.ascx" TagName="DisplayDetails" TagPrefix="de" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google chart</title>
    
    <script type="text/javascript" src="/Scripts/js/loader.js"></script>
    <script type="text/javascript" src="/Scripts/js/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="/Scripts/js/bootstrap.min.js"></script> 

    <link rel="stylesheet" href="/Scripts/js/bootstrap.min.css" />
    <link rel="stylesheet" href="/Scripts/css/custom.css" />

</head>
<body>
    <form id="form1" runat="server">

        <de:DisplayDetails id="DisplayDetailsModal" runat="server" />

    <div>

        <asp:DropDownList class="input-group col-sm-3 custom" ID="ddlCharType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCharType_SelectedIndexChanged">                                        
        </asp:DropDownList>
        
        <asp:CheckBox ID="chkOnclick" class="input-group col-sm-offset-1 custom" runat="server" 
            Visible="false" Text="Clickable" AutoPostBack="True" OnCheckedChanged="chkOnclick_CheckedChanged" />        
        <hr />

        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <asp:Panel ID="pnlChart" runat="server"></asp:Panel>
        <div id="chart_div"></div>    
    </div>   
    </form>
</body>    
</html>
