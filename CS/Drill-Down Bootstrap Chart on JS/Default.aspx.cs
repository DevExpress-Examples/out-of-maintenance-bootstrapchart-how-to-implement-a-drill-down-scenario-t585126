using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) { }
    protected void Cp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e) {
        if(e.Parameter == "restore")
            RestoreChart();
        else
            SwitchChart(e.Parameter);
    }
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
    void RestoreChart() {
        bootstrapbutton1.ClientEnabled = false;
        BootstrapChartBarSeries barSeries1 = new BootstrapChartBarSeries {
            ValueField = "sum",
            ArgumentField = "country",
            Name = "Summary"
        };
        BootstrapChart1.TitleText = "Fruits chart";
        BootstrapChart1.DataSourceUrl = "~/fruit.json";
        BindChart(barSeries1);
    }
    List<BootstrapChartDataItem> GetBootstrapChartData(Dictionary<string, string> dic) {
        List<BootstrapChartDataItem> bootstrapChartDataItems = new List<BootstrapChartDataItem>();
        foreach(var item in dic) {
            bootstrapChartDataItems.Add(new BootstrapChartDataItem(item.Key, decimal.Parse(item.Value)));
        }
        return bootstrapChartDataItems;
    }
    void BindChart(BootstrapChartBarSeries barSeries1) {
        BootstrapChart1.SeriesCollection.Clear();
        BootstrapChart1.SeriesCollection.Add(barSeries1);
        BootstrapChart1.DataBind();
    }
}