using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sorting_Visualiser.Renders
{
    class HorizontalSquare : RenderBase
    {
        public static IRender Default = new HorizontalSquare();
        public HorizontalSquare() => title = "Square (H)";

        public override SortElem[] New_Array(int len)
        {
            sortArray = new SortElem[len];
            colorList = Rainbow_Colors(len, 0, 128, 127);
            for (int i = 0; i < len; i++)
            {
                sortArray[i] = new SortElem(0, 2, 500, i, colorList[i]);
            }
            return sortArray;
        }


        public override void Render_Array(Grid grid)
        {
            grid.Children.Clear();
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.HorizontalAlignment = HorizontalAlignment.Right;
            for (int i = 0; i < sortArray.Length; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(column);

                Grid.SetColumn(sortArray[i].rect, i);
                grid.Children.Add(sortArray[i].rect);
            }
        }
    }
}
