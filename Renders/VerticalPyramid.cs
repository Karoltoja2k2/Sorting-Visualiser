using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sorting_Visualiser.Renders
{
    class VerticalPyramid : RenderBase
    {
        public static IRender Default = new VerticalPyramid();
        public VerticalPyramid() => title = "Pyramid (V)";



        public override SortElem[] New_Array(int len)
        {
            sortArray = new SortElem[len];
            colorList = Rainbow_Colors(len, 0, 128, 127);
            for (int i = 0; i < len; i++)
            {
                sortArray[i] = new SortElem(1, i, 2, i, colorList[i]);
            }
            return sortArray;
        }


        public override void Render_Array(Grid grid)
        {
            grid.Children.Clear();
            grid.VerticalAlignment = VerticalAlignment.Bottom;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            for (int i = 0; i < sortArray.Length; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);

                Grid.SetRow(sortArray[i].rect, i);
                grid.Children.Add(sortArray[i].rect);
            }

        }
    }
}
