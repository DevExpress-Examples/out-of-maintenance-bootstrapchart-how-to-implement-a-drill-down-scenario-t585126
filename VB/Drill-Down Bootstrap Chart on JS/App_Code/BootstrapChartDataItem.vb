Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class BootstrapChartDataItem
    Public Sub New(ByVal fruitCategory As String, ByVal categoryCount As Decimal)
        Me.FruitCategory = fruitCategory
        Me.CategoryCount = categoryCount
    End Sub
    Public Property FruitCategory() As String
    Public Property CategoryCount() As Decimal
End Class
