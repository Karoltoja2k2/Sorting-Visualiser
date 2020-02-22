using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sorting_Visualiser.Algorithms
{
    public abstract class SortBase : ISort
    {
        public MainWindow mainWin;
        public abstract SortElem[] Apply(SortElem[] sortArray);

        public SortBase()
        {
            App.Current.Dispatcher.Invoke(new Action(() => mainWin = (MainWindow)App.Current.MainWindow));
        }

        public void Swap(SortElem[] sortArray, int swap, int with)
        {
            SortElem temp = sortArray[swap];
            sortArray[swap] = sortArray[with];
            sortArray[with] = temp;
            App.Current.Dispatcher.Invoke(new Action(() => Display_Swap(sortArray, swap, with)));
        }

        public void Display_Swap(SortElem[] sortArray, int elem1, int elem2)
        {
            App.Current.Dispatcher.Invoke(new Action(() => Grid.SetColumn(sortArray[elem1].rect, elem1)));
            App.Current.Dispatcher.Invoke(new Action(() => Grid.SetColumn(sortArray[elem2].rect, elem2)));
        }

        public void Algorithm_Finish()
        {
            App.Current.Dispatcher.Invoke(new Action(() => mainWin.Buttons_Change_State(true)));
        }

    }
}
