using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BootstrapChartDataItem {
    public BootstrapChartDataItem(string fruitCategory, decimal categoryCount) {
        FruitCategory = fruitCategory;
        CategoryCount = categoryCount;
    }
    public string FruitCategory { get; set; }
    public decimal CategoryCount { get; set; }
}
