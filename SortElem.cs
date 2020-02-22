using System.Windows.Media;
using System.Windows.Shapes;

namespace Sorting_Visualiser
{
    public class SortElem
    {
        public int sortProp { get; set; }
        public Rectangle rect { get; set; }

        public SortElem(int width, int sortId, SolidColorBrush color)
        {
            rect = new Rectangle();
            rect.Width = width;
            rect.Fill = color;
            sortProp = sortId;
            rect.Height = sortId;

        }
    }
}
