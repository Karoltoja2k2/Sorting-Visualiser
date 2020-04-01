using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sorting_Visualiser.Renders
{
    public interface IRender
    {
        string ITitle { get;}

        SortElem[] New_Array(int size);
        void Render_Array(Grid grid);

        List<SolidColorBrush> Rainbow_Colors(int len, int phase, int center, int width);
    }
}
