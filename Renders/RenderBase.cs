using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sorting_Visualiser.Renders
{
    public abstract class RenderBase : IRender
    {
        public abstract SortElem[] New_Array(int len);
        public abstract void Render_Array(Grid grid);

        public SortElem[] sortArray;
        public List<SolidColorBrush> colorList;

        public string ITitle { get { return title; } }
        public string title;


        public List<SolidColorBrush> Rainbow_Colors(int len, int phase, int center, int width)
        {
            List<SolidColorBrush> colors = new List<SolidColorBrush>();
            double frequency = Math.PI * 2 / len;
            for (var i = 0; i < len; ++i)
            {
                double red = Math.Sin(frequency * i + 2 + phase) * width + center;
                double green = Math.Sin(frequency * i + 0 + phase) * width + center;
                double blue = Math.Sin(frequency * i + 4 + phase) * width + center;
                colors.Add(new SolidColorBrush(Color.FromRgb((byte)red, (byte)green, (byte)blue)));
            }
            return colors;
        }
    }
}
