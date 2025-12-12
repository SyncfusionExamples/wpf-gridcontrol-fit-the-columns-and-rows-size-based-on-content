# Fit the Columns and Rows Size Based on Custom Control Size

This example demonstrates how to adjust the column and row height based on custom control size

When [WPF GridControl](https://help.syncfusion.com/wpf/gridcontrol/overview) is placed inside custom control and if you want to auto fit the row/column size of `GridControl` based on custom control resized position, then you can invoke [SizeChanged](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.sizechanged?view=netframework-4.8) event of `GridControl` and set the [RowHeights](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_RowHeights) and [ColumnWidths](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_ColumnWidths) property of [GridModel](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html) to the resized height/width.

``` csharp
grid.SizeChanged += grid_SizeChanged;
//To autofit the cells based on custom control resizing,
void grid_SizeChanged(object sender, SizeChangedEventArgs e)
{
     double width = (e.NewSize.Width - grid.Model.ColumnWidths.DefaultLineSize - 1) / (grid.Model.ColumnCount - 1);
     double height = (e.NewSize.Height - grid.Model.RowHeights.DefaultLineSize - 1) / (grid.Model.RowCount - 1);
     for (int i = 1; i < grid.Model.ColumnCount; ++i)
        grid.Model.ColumnWidths[i] = width;
     for (int j = 1; j < grid.Model.RowCount; ++j)
        grid.Model.RowHeights[j] = height;
}
```
