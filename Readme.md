<!-- default file list -->
*Files to look at*:

* [BootstrapChartDataItem.cs](./CS/Drill-Down%20Bootstrap%20Chart%20on%20JS/App_Code/BootstrapChartDataItem.cs) (VB: [BootstrapChartDataItem.vb](./VB/Drill-Down%20Bootstrap%20Chart%20on%20JS/App_Code/BootstrapChartDataItem.vb))
* **[Default.aspx](./CS/Drill-Down%20Bootstrap%20Chart%20on%20JS/Default.aspx) (VB: [Default.aspx](./VB/Drill-Down%20Bootstrap%20Chart%20on%20JS/Default.aspx))**
* [Default.aspx.cs](./CS/Drill-Down%20Bootstrap%20Chart%20on%20JS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Drill-Down%20Bootstrap%20Chart%20on%20JS/Default.aspx.vb))
<!-- default file list end -->
# BootstrapChart - How to implement a Drill-Down scenario


This example demonstrates how to implement a Drill-Down scenario for BootstrapChart. The main idea of this approach is to switch a data source of the <a href="https://documentation.devexpress.com/AspNetBootstrap/DevExpress.Web.Bootstrap.BootstrapChart.class">BootstrapChart</a> control at runtime. To achieve this, handle the <strong>BootstrapClientChartBase.PointClick</strong> event, then create an appropriate array and pass it to the client-side <strong>PerformCallback</strong> method of the <a href="https://documentation.devexpress.com/AspNetBootstrap/DevExpress.Web.Bootstrap.BootstrapCallbackPanel.class">BootstrapCallbackPanel</a> control. In a callback event handler you need to perform an appropriate method to define the data source and properties, which is necessary to assign them to the BootstrapChart control.<br>


```js
function OnPointClick(s, e) {
            if (!button.GetEnabled()) {
                country = e.target.originalArgument;
                CreateNewArray(country);
                cp.PerformCallback(JSON.stringify(fruits) + "|" + country);
            }
        }
```


<br>


```cs
void SwitchChart(string parameter) {
        bootstrapbutton1.ClientEnabled = true;
        string[] paramArray = parameter.Split('|');
        var jss = new JavaScriptSerializer();
        Dictionary<string, string> dic = jss.Deserialize<Dictionary<string, string>>(paramArray[0]);
        BootstrapChartBarSeries barSeries1 = new BootstrapChartBarSeries {
            ValueField = "CategoryCount",
            ArgumentField = "FruitCategory",
            Name = "By groups"
        };
        BootstrapChart1.TitleText = string.Format("Fruits chart in {0}", paramArray[1]);
        BootstrapChart1.DataSource = GetBootstrapChartData(dic);
        BindChart(barSeries1);
    }
```



<br/>


