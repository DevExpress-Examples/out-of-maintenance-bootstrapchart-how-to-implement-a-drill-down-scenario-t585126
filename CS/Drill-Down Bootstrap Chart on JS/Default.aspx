<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BootstrapChart - How to implement a Drill-Down scenario</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        var fruitJson;
        var fruits = {};
        var country;
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: 'fruit.json',
                data: { },
                success: function (data) {
                    fruitJson = data
                }
            });
        });
        function OnPointClick(s, e) {
            if (!button.GetEnabled()) {
                country = e.target.originalArgument;
                CreateNewArray(country);
                cp.PerformCallback(JSON.stringify(fruits) + "|" + country);
            }
        }
        function CreateNewArray(country) {
            for (var i = 0; i < fruitJson.length; i++) {
                if (fruitJson[i]["country"] == country) {
                    Object.keys(fruitJson[i]).forEach(function (key) {
                        if (key != "country" && key != "sum")
                            fruits[key] = fruitJson[i][key];
                    });
                }
            }
        }
        function OnClick(s, e) {
            cp.PerformCallback("restore");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:BootstrapCallbackPanel runat="server" ClientInstanceName="cp" OnCallback="Cp_Callback">
                <ContentCollection>
                    <dx:ContentControl>
                        <dx:bootstrapbutton ID="bootstrapbutton1" ClientInstanceName="button" runat="server" Text="Back" ClientEnabled="false" AutoPostBack="false">
                            <ClientSideEvents Click="OnClick" />
                        </dx:bootstrapbutton>
                        <dx:BootstrapChart ID="BootstrapChart1" runat="server" DataSourceUrl="~/fruit.json" TitleText="Fruits chart">
                            <ClientSideEvents PointClick="OnPointClick" />
                            <SeriesCollection>
                                <dx:BootstrapChartBarSeries ArgumentField="country" ValueField="sum" Name="Summary" Visible="true"></dx:BootstrapChartBarSeries>
                            </SeriesCollection>
                        </dx:BootstrapChart>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapCallbackPanel>
        </div>
    </form>
</body>
</html>
