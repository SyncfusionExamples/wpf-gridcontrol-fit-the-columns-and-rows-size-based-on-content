using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Scroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            configureGrid();
        }


        // Help Functions
        private void configureGrid()
        {
            // Setting the number of rows and columns.
            grid.Model.RowCount = 10;
            grid.Model.ColumnCount = 10;
            // Setting the width and height of the cells.
            grid.Model.RowHeights.DefaultLineSize = 50;
            grid.Model.ColumnWidths.DefaultLineSize = 50;
           
            // Configuring headers
            configureHeaders();
            grid.SizeChanged += grid_SizeChanged;
            grid.Model.QueryCellInfo += Model_QueryCellInfo;
          
        }

        void grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
                      
            double width = (e.NewSize.Width - grid.Model.ColumnWidths.DefaultLineSize - 1) / (grid.Model.ColumnCount - 1);
            double height = (e.NewSize.Height - grid.Model.RowHeights.DefaultLineSize - 1) / (grid.Model.RowCount - 1);
            for (int i = 1; i < grid.Model.ColumnCount; ++i)
                grid.Model.ColumnWidths[i] = width;
            for (int j = 1; j < grid.Model.RowCount; ++j)
                grid.Model.RowHeights[j] = height;
            
        }

        void Model_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {

            if (e.Cell.RowIndex == 0 && e.Cell.ColumnIndex > 0)
            {
                e.Style.Text = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex == 0)
            {
                e.Style.Text = e.Cell.RowIndex.ToString();
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
            }
        }

       
       

        private void configureHeaders()
        {
            grid.Model.RowHeights[0] = 25;
            grid.Model.ColumnWidths[0] = 25;
            grid.Model.HeaderStyle.Background = new SolidColorBrush(Colors.NavajoWhite);
        }

      

       
    }
}
