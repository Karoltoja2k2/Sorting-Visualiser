using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sorting_Visualiser.Algorithms
{
    class SelectionSort : SortBase
    {
        public static ISort Default = new SelectionSort();

        public override SortElem[] Apply(SortElem[] sortArray)
        {
            int min;
            for (int i = 0; i < sortArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < sortArray.Length; j++)
                {
                    if (sortArray[j].sortProp < sortArray[min].sortProp)
                        min = j;
                }
                if (min != i)
                {
                    Swap(sortArray, i, min);
                    Application.Current.Dispatcher.Invoke(new Action(() => Grid.SetColumn(sortArray[i].rect, i)));
                    Application.Current.Dispatcher.Invoke(new Action(() => Grid.SetColumn(sortArray[min].rect, min)));
                    Thread.Sleep(5);
                }
            }
            return sortArray;
        }
    }
}
