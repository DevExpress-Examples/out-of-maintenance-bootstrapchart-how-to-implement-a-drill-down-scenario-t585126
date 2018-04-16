Option Infer On

Imports DevExpress.Web.Bootstrap
Imports System
Imports System.Collections.Generic
Imports System.Web.Script.Serialization

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Cp_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
        If e.Parameter = "restore" Then
            RestoreChart()
        Else
            SwitchChart(e.Parameter)
        End If
    End Sub
    Private Sub SwitchChart(ByVal parameter As String)
        bootstrapbutton1.ClientEnabled = True
        Dim [paramArray]() As String = parameter.Split("|"c)
        Dim jss = New JavaScriptSerializer()
        Dim dic As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))([paramArray](0))
        Dim barSeries1 As BootstrapChartBarSeries = New BootstrapChartBarSeries With { _
            .ValueField = "CategoryCount", _
            .ArgumentField = "FruitCategory", _
            .Name = "By groups" _
        }
        BootstrapChart1.TitleText = String.Format("Fruits chart in {0}", [paramArray](1))
        BootstrapChart1.DataSource = GetBootstrapChartData(dic)
        BindChart(barSeries1)
    End Sub
    Private Sub RestoreChart()
        bootstrapbutton1.ClientEnabled = False
        Dim barSeries1 As BootstrapChartBarSeries = New BootstrapChartBarSeries With { _
            .ValueField = "sum", _
            .ArgumentField = "country", _
            .Name = "Summary" _
        }
        BootstrapChart1.TitleText = "Fruits chart"
        BootstrapChart1.DataSourceUrl = "~/fruit.json"
        BindChart(barSeries1)
    End Sub
    Private Function GetBootstrapChartData(ByVal dic As Dictionary(Of String, String)) As List(Of BootstrapChartDataItem)
        Dim bootstrapChartDataItems As New List(Of BootstrapChartDataItem)()
        For Each item In dic
            bootstrapChartDataItems.Add(New BootstrapChartDataItem(item.Key, Decimal.Parse(item.Value)))
        Next item
        Return bootstrapChartDataItems
    End Function
    Private Sub BindChart(ByVal barSeries1 As BootstrapChartBarSeries)
        BootstrapChart1.SeriesCollection.Clear()
        BootstrapChart1.SeriesCollection.Add(barSeries1)
        BootstrapChart1.DataBind()
    End Sub
End Class