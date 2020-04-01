using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sorting_Visualiser
{
    public class SortElem
    {
        public int sortProp { get; set; }
        public Rectangle rect { get; set; }
        public int orientation;

        /// <summary>
        ///     Orientation 0 - horizontal pyramid(height = iterator), square(height = const.)  
        ///     Orientation 1 - vertical pyramid(width = iterator), squara(width = const.)
        /// </summary>
        public SortElem(int orientation, int width, int height, int sortId, SolidColorBrush color)
        {
            this.orientation = orientation;
            sortProp = sortId;

            rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;

            rect.Fill = color;
        }

        public void Set_Pos(int pos)
        {
            if (orientation == 0)
                Grid.SetColumn(rect, pos);
            if (orientation == 1)
                Grid.SetRow(rect, pos);
        }

        public int Get_Pos()
        {
            if (orientation == 0)
                return Grid.GetColumn(rect);
            else
                return Grid.GetRow(rect);
        }
    }
}
 