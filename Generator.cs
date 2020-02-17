using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sorting_Visualiser
{
    public class Generator
    {
        public List<SolidColorBrush> colorList;
        public SortElem[] sortArray;

        public SortElem[] New_Array(int size)
        {
            sortArray = new SortElem[size];
            colorList = Rainbow_Colors(size);
            for (int i = 0; i < size; i++)
            {
                sortArray[i] = new SortElem(2, i, colorList[i]);
            }
            return sortArray;
        }

        public List<SolidColorBrush> Rainbow_Colors(int len)
        {
            List<SolidColorBrush> colors = new List<SolidColorBrush>();
    
            int phase = 0;
            int center = 128;
            int width = 127;
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
